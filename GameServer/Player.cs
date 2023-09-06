using Net.Server;
using Net.Share;

namespace GameServer
{
    public class Player : NetPlayer
    {
        public UserinfoData data;
        public override void OnStart()//当登陆成功调用
        {
            base.OnStart();
            AddRpc(data);
        }

        public override void OnSignOut()//当退出登录
        {
            base.OnSignOut();
            RemoveRpc(data);
            data = null;
        }

        public override void OnRpcExecute(RPCModel model)
        {
            switch (model.methodHash)
            {
                default:
                    base.OnRpcExecute(model);
                    break;
            }
        }
    }
}