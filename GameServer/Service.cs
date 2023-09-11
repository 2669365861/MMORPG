using Net.Server;
using Net.Share;
using Game;
using System;

namespace GameServer
{
    public class Service : TcpServer<Player, Scene>
    {
        protected override bool OnUnClientRequest(Player unClient, RPCModel model)
        {
            switch ((ProtoType)model.methodHash)
            {
                case ProtoType.Register:
                    Register(unClient, model.AsString, model.AsString);
                    break;
                case ProtoType.Login:
                    Login(unClient, model.AsString, model.AsString);
                    break;
            }
            return false;
        }

        protected override void OnRpcExecute(Player client, RPCModel model)
        {
            switch ((ProtoType)model.methodHash)
            {
                case ProtoType.Nick:
                    SetNick(client, model.AsString);
                    break;
                case ProtoType.Login://避免请求已经进入服务器，但是客户端超时的情况
                    Login(client, model.AsString, model.AsString);
                    break;
            }
        }

        private void SetNick(Player client, string nick)
        {
            client.data.Nick = nick;
            SendRT(client, (ushort)ProtoType.Nick, 0);
        }

        private void Register(Player client, string account, string password)
        {
            if (GameDB.I.TryGetUser(account, out var data))
            {
                SendRT(client, (ushort)ProtoType.Register, -1);//账号已存在
                return;
            }
            var id = GameDB.I.ConfigAdd(ConfigType.UserInfo);//userinfo自增id
            var uid = GameDB.I.ConfigAdd(ConfigType.UserInfo_Uid);//userinfo_uid自增id
            data = new UserinfoData();
            data.Id = id;
            data.Account = account;
            data.Password = password;
            data.NewTableRow();//提交到数据库
            GameDB.I.AddUser(data);
            SendRT(client, (ushort)ProtoType.Register, 0);//注册成功
        }

        private void Login(Player client, string account, string password)
        {
            if (!GameDB.I.TryGetUser(account, out var data))
            {
                SendRT(client, (ushort)ProtoType.Login, -2,null);//账号不存在
                return;
            }
            if (data.Password != password)
            {
                SendRT(client, (ushort)ProtoType.Login, -1,null);//密码错误
                return;
            }
            client.data = data;
            SendRT(client, (ushort)ProtoType.Login, 0,data);//登陆成功
            LoginHandler(client);//内核登录
        }
    }
}
