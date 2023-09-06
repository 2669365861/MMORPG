using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Net.Share;
using Net.Event;

#if SERVER
using Net.System;
using Cysharp.Threading.Tasks;
using MySql.Data.MySqlClient;
using Game;
#endif
using BooleanObs = Net.Common.PropertyObserverAuto<bool>;
using ByteObs = Net.Common.PropertyObserverAuto<byte>;
using SByteObs = Net.Common.PropertyObserverAuto<sbyte>;
using Int16Obs = Net.Common.PropertyObserverAuto<short>;
using UInt16Obs = Net.Common.PropertyObserverAuto<ushort>;
using CharObs = Net.Common.PropertyObserverAuto<char>;
using Int32Obs = Net.Common.PropertyObserverAuto<int>;
using UInt32Obs = Net.Common.PropertyObserverAuto<uint>;
using SingleObs = Net.Common.PropertyObserverAuto<float>;
using Int64Obs = Net.Common.PropertyObserverAuto<long>;
using UInt64Obs = Net.Common.PropertyObserverAuto<ulong>;
using DoubleObs = Net.Common.PropertyObserverAuto<double>;
using DateTimeObs = Net.Common.PropertyObserverAuto<System.DateTime>;
using BytesObs = Net.Common.PropertyObserverAuto<byte[]>;
using StringObs = Net.Common.PropertyObserverAuto<string>;


/// <summary>
/// 此类由MySqlDataBuild工具生成, 请不要在此类编辑代码! 请新建一个类文件进行分写
/// <para>MySqlDataBuild工具提供Rpc自动同步到mysql数据库的功能, 提供数据库注释功能</para>
/// <para><see href="此脚本支持防内存修改器, 需要在uniyt的预编译处添加:ANTICHEAT关键字即可"/> </para>
/// MySqlDataBuild工具gitee地址:https://gitee.com/leng_yue/my-sql-data-build
/// </summary>
public partial class UserinfoData : IDataRow
    {
        [Net.Serialize.NonSerialized]
        [Newtonsoft_X.Json.JsonIgnore]
        public DataRowState RowState { get; set; }
    #if SERVER
        internal Net.Server.NetPlayer client;
    #endif
        /// <summary>当属性被修改时调用, 参数1: 哪个字段被修改(表名_字段名), 参数2:被修改的值</summary>
        [Net.Serialize.NonSerialized]
        [Newtonsoft_X.Json.JsonIgnore]
        public Action<GameHashProto, object> OnValueChanged;

        private Int32 id;
        /// <summary>表id</summary>
        public Int32 Id { get { return id; } set { this.id = value; } }

     //1
        private readonly Int32Obs uid = new Int32Obs("UserinfoData_uid", true, null);

        /// <summary>玩家uid --获得属性观察对象</summary>
        internal Int32Obs UidObserver => uid;

        /// <summary>玩家uid</summary>
        public Int32 Uid { get => GetUidValue(); set => CheckUidValue(value, 0); }

        /// <summary>玩家uid --同步到数据库</summary>
        internal Int32 SyncUid { get => GetUidValue(); set => CheckUidValue(value, 1); }

        /// <summary>玩家uid --同步带有Key字段的值到服务器Player对象上，需要处理</summary>
        internal Int32 SyncIDUid { get => GetUidValue(); set => CheckUidValue(value, 2); }

        private Int32 GetUidValue() => this.uid.Value;

        private void CheckUidValue(Int32 value, int type) 
        {
            if (this.uid.Value == value)
                return;
            this.uid.Value = value;
            if (type == 0)
                CheckUpdate(1);
            else if (type == 1)
                UidCall(false);
            else if (type == 2)
                UidCall(true);
            OnValueChanged?.Invoke(GameHashProto.USERINFO_UID, value);
        }

        /// <summary>玩家uid --同步当前值到服务器Player对象上，需要处理</summary>
        public void UidCall(bool syncId = false)
        {
            
            object[] objects;
            if (syncId) objects = new object[] { this[GameDBEvent.UserinfoData_SyncID], uid.Value };
            else objects = new object[] { uid.Value };
#if SERVER
            CheckUpdate(1);
            GameDBEvent.OnSyncProperty?.Invoke(client, NetCmd.SyncPropertyData, (ushort)GameHashProto.USERINFO_UID, objects);
#else
            GameDBEvent.Client.SendRT(NetCmd.SyncPropertyData, (ushort)GameHashProto.USERINFO_UID, objects);
#endif
        }

        [Rpc(hash = (ushort)GameHashProto.USERINFO_UID)]
        private void UidRpc(Int32 value)//重写NetPlayer的OnStart方法来处理客户端自动同步到服务器数据库, 方法内部添加AddRpc(data(UserinfoData));收集Rpc
        {
            Uid = value;
        }
     //1
        private readonly StringObs account = new StringObs("UserinfoData_account", false, null);

        /// <summary>账号 --获得属性观察对象</summary>
        internal StringObs AccountObserver => account;

        /// <summary>账号</summary>
        public String Account { get => GetAccountValue(); set => CheckAccountValue(value, 0); }

        /// <summary>账号 --同步到数据库</summary>
        internal String SyncAccount { get => GetAccountValue(); set => CheckAccountValue(value, 1); }

        /// <summary>账号 --同步带有Key字段的值到服务器Player对象上，需要处理</summary>
        internal String SyncIDAccount { get => GetAccountValue(); set => CheckAccountValue(value, 2); }

        private String GetAccountValue() => this.account.Value;

        private void CheckAccountValue(String value, int type) 
        {
            if (this.account.Value == value)
                return;
            this.account.Value = value;
            if (type == 0)
                CheckUpdate(2);
            else if (type == 1)
                AccountCall(false);
            else if (type == 2)
                AccountCall(true);
            OnValueChanged?.Invoke(GameHashProto.USERINFO_ACCOUNT, value);
        }

        /// <summary>账号 --同步当前值到服务器Player对象上，需要处理</summary>
        public void AccountCall(bool syncId = false)
        {
            
            object[] objects;
            if (syncId) objects = new object[] { this[GameDBEvent.UserinfoData_SyncID], account.Value };
            else objects = new object[] { account.Value };
#if SERVER
            CheckUpdate(2);
            GameDBEvent.OnSyncProperty?.Invoke(client, NetCmd.SyncPropertyData, (ushort)GameHashProto.USERINFO_ACCOUNT, objects);
#else
            GameDBEvent.Client.SendRT(NetCmd.SyncPropertyData, (ushort)GameHashProto.USERINFO_ACCOUNT, objects);
#endif
        }

        [Rpc(hash = (ushort)GameHashProto.USERINFO_ACCOUNT)]
        private void AccountRpc(String value)//重写NetPlayer的OnStart方法来处理客户端自动同步到服务器数据库, 方法内部添加AddRpc(data(UserinfoData));收集Rpc
        {
            Account = value;
        }
     //1
        private readonly StringObs password = new StringObs("UserinfoData_password", false, null);

        /// <summary>密码 --获得属性观察对象</summary>
        internal StringObs PasswordObserver => password;

        /// <summary>密码</summary>
        public String Password { get => GetPasswordValue(); set => CheckPasswordValue(value, 0); }

        /// <summary>密码 --同步到数据库</summary>
        internal String SyncPassword { get => GetPasswordValue(); set => CheckPasswordValue(value, 1); }

        /// <summary>密码 --同步带有Key字段的值到服务器Player对象上，需要处理</summary>
        internal String SyncIDPassword { get => GetPasswordValue(); set => CheckPasswordValue(value, 2); }

        private String GetPasswordValue() => this.password.Value;

        private void CheckPasswordValue(String value, int type) 
        {
            if (this.password.Value == value)
                return;
            this.password.Value = value;
            if (type == 0)
                CheckUpdate(3);
            else if (type == 1)
                PasswordCall(false);
            else if (type == 2)
                PasswordCall(true);
            OnValueChanged?.Invoke(GameHashProto.USERINFO_PASSWORD, value);
        }

        /// <summary>密码 --同步当前值到服务器Player对象上，需要处理</summary>
        public void PasswordCall(bool syncId = false)
        {
            
            object[] objects;
            if (syncId) objects = new object[] { this[GameDBEvent.UserinfoData_SyncID], password.Value };
            else objects = new object[] { password.Value };
#if SERVER
            CheckUpdate(3);
            GameDBEvent.OnSyncProperty?.Invoke(client, NetCmd.SyncPropertyData, (ushort)GameHashProto.USERINFO_PASSWORD, objects);
#else
            GameDBEvent.Client.SendRT(NetCmd.SyncPropertyData, (ushort)GameHashProto.USERINFO_PASSWORD, objects);
#endif
        }

        [Rpc(hash = (ushort)GameHashProto.USERINFO_PASSWORD)]
        private void PasswordRpc(String value)//重写NetPlayer的OnStart方法来处理客户端自动同步到服务器数据库, 方法内部添加AddRpc(data(UserinfoData));收集Rpc
        {
            Password = value;
        }
     //1
        private readonly StringObs nick = new StringObs("UserinfoData_nick", false, null);

        /// <summary>昵称 --获得属性观察对象</summary>
        internal StringObs NickObserver => nick;

        /// <summary>昵称</summary>
        public String Nick { get => GetNickValue(); set => CheckNickValue(value, 0); }

        /// <summary>昵称 --同步到数据库</summary>
        internal String SyncNick { get => GetNickValue(); set => CheckNickValue(value, 1); }

        /// <summary>昵称 --同步带有Key字段的值到服务器Player对象上，需要处理</summary>
        internal String SyncIDNick { get => GetNickValue(); set => CheckNickValue(value, 2); }

        private String GetNickValue() => this.nick.Value;

        private void CheckNickValue(String value, int type) 
        {
            if (this.nick.Value == value)
                return;
            this.nick.Value = value;
            if (type == 0)
                CheckUpdate(4);
            else if (type == 1)
                NickCall(false);
            else if (type == 2)
                NickCall(true);
            OnValueChanged?.Invoke(GameHashProto.USERINFO_NICK, value);
        }

        /// <summary>昵称 --同步当前值到服务器Player对象上，需要处理</summary>
        public void NickCall(bool syncId = false)
        {
            
            object[] objects;
            if (syncId) objects = new object[] { this[GameDBEvent.UserinfoData_SyncID], nick.Value };
            else objects = new object[] { nick.Value };
#if SERVER
            CheckUpdate(4);
            GameDBEvent.OnSyncProperty?.Invoke(client, NetCmd.SyncPropertyData, (ushort)GameHashProto.USERINFO_NICK, objects);
#else
            GameDBEvent.Client.SendRT(NetCmd.SyncPropertyData, (ushort)GameHashProto.USERINFO_NICK, objects);
#endif
        }

        [Rpc(hash = (ushort)GameHashProto.USERINFO_NICK)]
        private void NickRpc(String value)//重写NetPlayer的OnStart方法来处理客户端自动同步到服务器数据库, 方法内部添加AddRpc(data(UserinfoData));收集Rpc
        {
            Nick = value;
        }
     //1
        private readonly Int32Obs level = new Int32Obs("UserinfoData_level", true, null);

        /// <summary>等级 --获得属性观察对象</summary>
        internal Int32Obs LevelObserver => level;

        /// <summary>等级</summary>
        public Int32 Level { get => GetLevelValue(); set => CheckLevelValue(value, 0); }

        /// <summary>等级 --同步到数据库</summary>
        internal Int32 SyncLevel { get => GetLevelValue(); set => CheckLevelValue(value, 1); }

        /// <summary>等级 --同步带有Key字段的值到服务器Player对象上，需要处理</summary>
        internal Int32 SyncIDLevel { get => GetLevelValue(); set => CheckLevelValue(value, 2); }

        private Int32 GetLevelValue() => this.level.Value;

        private void CheckLevelValue(Int32 value, int type) 
        {
            if (this.level.Value == value)
                return;
            this.level.Value = value;
            if (type == 0)
                CheckUpdate(5);
            else if (type == 1)
                LevelCall(false);
            else if (type == 2)
                LevelCall(true);
            OnValueChanged?.Invoke(GameHashProto.USERINFO_LEVEL, value);
        }

        /// <summary>等级 --同步当前值到服务器Player对象上，需要处理</summary>
        public void LevelCall(bool syncId = false)
        {
            
            object[] objects;
            if (syncId) objects = new object[] { this[GameDBEvent.UserinfoData_SyncID], level.Value };
            else objects = new object[] { level.Value };
#if SERVER
            CheckUpdate(5);
            GameDBEvent.OnSyncProperty?.Invoke(client, NetCmd.SyncPropertyData, (ushort)GameHashProto.USERINFO_LEVEL, objects);
#else
            GameDBEvent.Client.SendRT(NetCmd.SyncPropertyData, (ushort)GameHashProto.USERINFO_LEVEL, objects);
#endif
        }

        [Rpc(hash = (ushort)GameHashProto.USERINFO_LEVEL)]
        private void LevelRpc(Int32 value)//重写NetPlayer的OnStart方法来处理客户端自动同步到服务器数据库, 方法内部添加AddRpc(data(UserinfoData));收集Rpc
        {
            Level = value;
        }
     //1
        private readonly Int32Obs exp = new Int32Obs("UserinfoData_exp", true, null);

        /// <summary>经验值 --获得属性观察对象</summary>
        internal Int32Obs ExpObserver => exp;

        /// <summary>经验值</summary>
        public Int32 Exp { get => GetExpValue(); set => CheckExpValue(value, 0); }

        /// <summary>经验值 --同步到数据库</summary>
        internal Int32 SyncExp { get => GetExpValue(); set => CheckExpValue(value, 1); }

        /// <summary>经验值 --同步带有Key字段的值到服务器Player对象上，需要处理</summary>
        internal Int32 SyncIDExp { get => GetExpValue(); set => CheckExpValue(value, 2); }

        private Int32 GetExpValue() => this.exp.Value;

        private void CheckExpValue(Int32 value, int type) 
        {
            if (this.exp.Value == value)
                return;
            this.exp.Value = value;
            if (type == 0)
                CheckUpdate(6);
            else if (type == 1)
                ExpCall(false);
            else if (type == 2)
                ExpCall(true);
            OnValueChanged?.Invoke(GameHashProto.USERINFO_EXP, value);
        }

        /// <summary>经验值 --同步当前值到服务器Player对象上，需要处理</summary>
        public void ExpCall(bool syncId = false)
        {
            
            object[] objects;
            if (syncId) objects = new object[] { this[GameDBEvent.UserinfoData_SyncID], exp.Value };
            else objects = new object[] { exp.Value };
#if SERVER
            CheckUpdate(6);
            GameDBEvent.OnSyncProperty?.Invoke(client, NetCmd.SyncPropertyData, (ushort)GameHashProto.USERINFO_EXP, objects);
#else
            GameDBEvent.Client.SendRT(NetCmd.SyncPropertyData, (ushort)GameHashProto.USERINFO_EXP, objects);
#endif
        }

        [Rpc(hash = (ushort)GameHashProto.USERINFO_EXP)]
        private void ExpRpc(Int32 value)//重写NetPlayer的OnStart方法来处理客户端自动同步到服务器数据库, 方法内部添加AddRpc(data(UserinfoData));收集Rpc
        {
            Exp = value;
        }
     //2

        public UserinfoData() { }

    #if SERVER
        public UserinfoData(params object[] parms) : base()
        {
            NewTableRow(parms);
        }
        public void NewTableRow()
        {
            RowState = DataRowState.Added;
            GameDB.I.Update(this);
        }
        public object GetDefaultValue(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
        public void NewTableRow(params object[] parms)
        {
            if (parms == null)
                return;
            if (parms.Length == 0)
                return;
            for (int i = 0; i < parms.Length; i++)
            {
                if (parms[i] == null)
                    continue;
                this[i] = parms[i];
            }
            RowState = DataRowState.Added;
            GameDB.I.Update(this);
        }
        public string GetCellNameAndTextLength(int index, out uint length)
        {
            switch (index)
            {
     //3
                case 0: length = 0; return "id";
     //3
                case 1: length = 0; return "uid";
     //3
                case 2: length = 255; return "account";
     //3
                case 3: length = 255; return "password";
     //3
                case 4: length = 255; return "nick";
     //3
                case 5: length = 0; return "level";
     //3
                case 6: length = 0; return "exp";
     //4
            }
            throw new Exception("错误");
        }
    #endif

        public object this[int index]
        {
            get
            {
                switch (index)
                {
     //5
                    case 0: return this.id;
     //5
                    case 1: return this.uid.Value;
     //5
                    case 2: return this.account.Value;
     //5
                    case 3: return this.password.Value;
     //5
                    case 4: return this.nick.Value;
     //5
                    case 5: return this.level.Value;
     //5
                    case 6: return this.exp.Value;
     //6
                }
                throw new Exception("错误");
            }
            set
            {
                switch (index)
                {
     //7
                    case 0:
                        this.id = (Int32)value;
                        break;
     //7
                    case 1:
                        CheckUidValue((Int32)value, -1);
                        break;
     //7
                    case 2:
                        CheckAccountValue((String)value, -1);
                        break;
     //7
                    case 3:
                        CheckPasswordValue((String)value, -1);
                        break;
     //7
                    case 4:
                        CheckNickValue((String)value, -1);
                        break;
     //7
                    case 5:
                        CheckLevelValue((Int32)value, -1);
                        break;
     //7
                    case 6:
                        CheckExpValue((Int32)value, -1);
                        break;
     //8
                }
            }
        }

        public object this[string name]
        {
            get
            {
                switch (name)
                {
     //9
                    case "id": return this.id;
     //9
                    case "uid": return this.uid.Value;
     //9
                    case "account": return this.account.Value;
     //9
                    case "password": return this.password.Value;
     //9
                    case "nick": return this.nick.Value;
     //9
                    case "level": return this.level.Value;
     //9
                    case "exp": return this.exp.Value;
     //10
                }
                throw new Exception("错误");
            }
            set
            {
                switch (name)
                {
     //11
                    case "id":
                        this.id = (Int32)value;
                        break;
     //11
                    case "uid":
                        CheckUidValue((Int32)value, -1);
                        break;
     //11
                    case "account":
                        CheckAccountValue((String)value, -1);
                        break;
     //11
                    case "password":
                        CheckPasswordValue((String)value, -1);
                        break;
     //11
                    case "nick":
                        CheckNickValue((String)value, -1);
                        break;
     //11
                    case "level":
                        CheckLevelValue((Int32)value, -1);
                        break;
     //11
                    case "exp":
                        CheckExpValue((Int32)value, -1);
                        break;
     //12
                }
            }
        }

    #if SERVER
        public void Delete(bool immediately = false)
        {
            if (immediately)
            {
                var sb = new StringBuilder();
                DeletedSql(sb);
                _ = GameDB.I.ExecuteNonQuery(sb.ToString(), null);
            }
            else
            {
                RowState = DataRowState.Detached;
                GameDB.I.Update(this);
            }
        }

        /// <summary>
        /// 查询1: Query("`id`=1");
        /// <para></para>
        /// 查询2: Query("`id`=1 and `index`=1");
        /// <para></para>
        /// 查询3: Query("`id`=1 or `index`=1");
        /// </summary>
        /// <param name="filterExpression"></param>
        /// <returns></returns>
        public static UserinfoData Query(string filterExpression)
        {
            var cmdText = $"select * from userinfo where {filterExpression}; ";
            var data = GameDB.I.ExecuteQuery<UserinfoData>(cmdText);
            return data;
        }
        /// <summary>
        /// 查询1: Query("`id`=1");
        /// <para></para>
        /// 查询2: Query("`id`=1 and `index`=1");
        /// <para></para>
        /// 查询3: Query("`id`=1 or `index`=1");
        /// </summary>
        /// <param name="filterExpression"></param>
        /// <returns></returns>
        public static async UniTask<UserinfoData> QueryAsync(string filterExpression)
        {
            var cmdText = $"select * from userinfo where {filterExpression}; ";
            var data = await GameDB.I.ExecuteQueryAsync<UserinfoData>(cmdText);
            return data;
        }
        public static UserinfoData[] QueryList(string filterExpression)
        {
            var cmdText = $"select * from userinfo where {filterExpression}; ";
            var datas = GameDB.I.ExecuteQueryList<UserinfoData>(cmdText);
            return datas;
        }
        public static async UniTask<UserinfoData[]> QueryListAsync(string filterExpression)
        {
            var cmdText = $"select * from userinfo where {filterExpression}; ";
            var datas = await GameDB.I.ExecuteQueryListAsync<UserinfoData>(cmdText);
            return datas;
        }
        public void Update()
        {
            if (RowState == DataRowState.Deleted | RowState == DataRowState.Detached | RowState == DataRowState.Added | RowState == 0) return;
     //14
        }
    #endif

        public void Init(DataRow row)
        {
            RowState = DataRowState.Unchanged;
     //15
            if (row[0] is Int32 id)
                this.id = id;
     //15
            if (row[1] is Int32 uid)
                CheckUidValue(uid, -1);
     //15
            if (row[2] is String account)
                CheckAccountValue(account, -1);
     //15
            if (row[3] is String password)
                CheckPasswordValue(password, -1);
     //15
            if (row[4] is String nick)
                CheckNickValue(nick, -1);
     //15
            if (row[5] is Int32 level)
                CheckLevelValue(level, -1);
     //15
            if (row[6] is Int32 exp)
                CheckExpValue(exp, -1);
     //16
        }

        public void AddedSql(StringBuilder sb)
        {
    #if SERVER
    
            BulkLoaderBuilder(sb);
    
            RowState = DataRowState.Unchanged;
    #endif
        }

        public void ModifiedSql(StringBuilder sb)
        {
    #if SERVER
            if (RowState == DataRowState.Detached | RowState == DataRowState.Deleted | RowState == DataRowState.Added | RowState == 0)
                return;
            BulkLoaderBuilder(sb);
            RowState = DataRowState.Unchanged;
    #endif
        }

        public void DeletedSql(StringBuilder sb)
        {
    #if SERVER
            if (RowState == DataRowState.Deleted)
                return;
            string cmdText = $"DELETE FROM userinfo {CheckSqlKey(0, id)}";
            sb.Append(cmdText);
            RowState = DataRowState.Deleted;
    #endif
        }

    #if SERVER
        public void BulkLoaderBuilder(StringBuilder sb)
        {
 
            for (int i = 0; i < 7; i++)
            {
                var name = GetCellNameAndTextLength(i, out var length);
                var value = this[i];
                if (value == null) //空的值会导致sql语句错误
                {
                    sb.Append(@"\N|");
                    continue;
                }
                if (value is string text)
                {
                    GameDB.I.CheckStringValue(ref text, length);
                    sb.Append(text + "|");
                }
                else if (value is DateTime dateTime)
                {
                    sb.Append(dateTime.ToString("yyyy-MM-dd HH:mm:ss") + "|");
                }
                else if (value is bool boolVal)
                {
                    sb.Append(boolVal ? "1|" : "0|");
                }
                else if (value is byte[] buffer)
                {
                    var base64Str = Convert.ToBase64String(buffer, Base64FormattingOptions.None);
                    if (buffer.Length >= length)
                    {
                        NDebug.LogError($"userinfo表{name}列长度溢出!");
                        sb.Append(@"\N|");
                        continue;
                    }
                    sb.Append(base64Str + "|");
                }
                else 
                {
                    sb.Append(value + "|");
                }
            }
            sb.AppendLine();
 
        }
    #endif

    #if SERVER
        private string CheckSqlKey(int column, object value)
        {
            var name = GetCellNameAndTextLength(column, out var length);
            if (value == null) //空的值会导致sql语句错误
                return "";
            if (value is string text)
            {
                GameDB.I.CheckStringValue(ref text, length);
                return $" WHERE `{name}`='{text}'; ";
            }
            else if (value is DateTime)
                return $" WHERE `{name}`='{value}'; ";
            else if (value is byte[])
                return "";
            return $" WHERE `{name}`={value}; ";
        }
    #endif

        private void CheckUpdate(int cellIndex)
        {
#if SERVER
            if (RowState == DataRowState.Deleted | RowState == DataRowState.Detached) return;
            if (RowState != DataRowState.Added & RowState != 0)//如果还没初始化或者创建新行,只能修改值不能更新状态
                RowState = DataRowState.Modified;
            GameDB.I.Update(this);
#endif
        }

        public override string ToString()
        {
            return $"Id:{Id} Uid:{Uid} Account:{Account} Password:{Password} Nick:{Nick} Level:{Level} Exp:{Exp} ";
        }
    }
