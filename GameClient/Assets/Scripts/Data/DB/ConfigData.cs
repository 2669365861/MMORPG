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
public partial class ConfigData : IDataRow
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
        private readonly StringObs name = new StringObs("ConfigData_name", false, null);

        /// <summary>表名 --获得属性观察对象</summary>
        internal StringObs NameObserver => name;

        /// <summary>表名</summary>
        public String Name { get => GetNameValue(); set => CheckNameValue(value, 0); }

        /// <summary>表名 --同步到数据库</summary>
        internal String SyncName { get => GetNameValue(); set => CheckNameValue(value, 1); }

        /// <summary>表名 --同步带有Key字段的值到服务器Player对象上，需要处理</summary>
        internal String SyncIDName { get => GetNameValue(); set => CheckNameValue(value, 2); }

        private String GetNameValue() => this.name.Value;

        private void CheckNameValue(String value, int type) 
        {
            if (this.name.Value == value)
                return;
            this.name.Value = value;
            if (type == 0)
                CheckUpdate(1);
            else if (type == 1)
                NameCall(false);
            else if (type == 2)
                NameCall(true);
            OnValueChanged?.Invoke(GameHashProto.CONFIG_NAME, value);
        }

        /// <summary>表名 --同步当前值到服务器Player对象上，需要处理</summary>
        public void NameCall(bool syncId = false)
        {
            
            object[] objects;
            if (syncId) objects = new object[] { this[GameDBEvent.ConfigData_SyncID], name.Value };
            else objects = new object[] { name.Value };
#if SERVER
            CheckUpdate(1);
            GameDBEvent.OnSyncProperty?.Invoke(client, NetCmd.SyncPropertyData, (ushort)GameHashProto.CONFIG_NAME, objects);
#else
            GameDBEvent.Client.SendRT(NetCmd.SyncPropertyData, (ushort)GameHashProto.CONFIG_NAME, objects);
#endif
        }

        [Rpc(hash = (ushort)GameHashProto.CONFIG_NAME)]
        private void NameRpc(String value)//重写NetPlayer的OnStart方法来处理客户端自动同步到服务器数据库, 方法内部添加AddRpc(data(ConfigData));收集Rpc
        {
            Name = value;
        }
     //1
        private readonly Int32Obs count = new Int32Obs("ConfigData_count", true, null);

        /// <summary>表计数 --获得属性观察对象</summary>
        internal Int32Obs CountObserver => count;

        /// <summary>表计数</summary>
        public Int32 Count { get => GetCountValue(); set => CheckCountValue(value, 0); }

        /// <summary>表计数 --同步到数据库</summary>
        internal Int32 SyncCount { get => GetCountValue(); set => CheckCountValue(value, 1); }

        /// <summary>表计数 --同步带有Key字段的值到服务器Player对象上，需要处理</summary>
        internal Int32 SyncIDCount { get => GetCountValue(); set => CheckCountValue(value, 2); }

        private Int32 GetCountValue() => this.count.Value;

        private void CheckCountValue(Int32 value, int type) 
        {
            if (this.count.Value == value)
                return;
            this.count.Value = value;
            if (type == 0)
                CheckUpdate(2);
            else if (type == 1)
                CountCall(false);
            else if (type == 2)
                CountCall(true);
            OnValueChanged?.Invoke(GameHashProto.CONFIG_COUNT, value);
        }

        /// <summary>表计数 --同步当前值到服务器Player对象上，需要处理</summary>
        public void CountCall(bool syncId = false)
        {
            
            object[] objects;
            if (syncId) objects = new object[] { this[GameDBEvent.ConfigData_SyncID], count.Value };
            else objects = new object[] { count.Value };
#if SERVER
            CheckUpdate(2);
            GameDBEvent.OnSyncProperty?.Invoke(client, NetCmd.SyncPropertyData, (ushort)GameHashProto.CONFIG_COUNT, objects);
#else
            GameDBEvent.Client.SendRT(NetCmd.SyncPropertyData, (ushort)GameHashProto.CONFIG_COUNT, objects);
#endif
        }

        [Rpc(hash = (ushort)GameHashProto.CONFIG_COUNT)]
        private void CountRpc(Int32 value)//重写NetPlayer的OnStart方法来处理客户端自动同步到服务器数据库, 方法内部添加AddRpc(data(ConfigData));收集Rpc
        {
            Count = value;
        }
     //1
        private readonly StringObs des = new StringObs("ConfigData_des", false, null);

        /// <summary>说明 --获得属性观察对象</summary>
        internal StringObs DesObserver => des;

        /// <summary>说明</summary>
        public String Des { get => GetDesValue(); set => CheckDesValue(value, 0); }

        /// <summary>说明 --同步到数据库</summary>
        internal String SyncDes { get => GetDesValue(); set => CheckDesValue(value, 1); }

        /// <summary>说明 --同步带有Key字段的值到服务器Player对象上，需要处理</summary>
        internal String SyncIDDes { get => GetDesValue(); set => CheckDesValue(value, 2); }

        private String GetDesValue() => this.des.Value;

        private void CheckDesValue(String value, int type) 
        {
            if (this.des.Value == value)
                return;
            this.des.Value = value;
            if (type == 0)
                CheckUpdate(3);
            else if (type == 1)
                DesCall(false);
            else if (type == 2)
                DesCall(true);
            OnValueChanged?.Invoke(GameHashProto.CONFIG_DES, value);
        }

        /// <summary>说明 --同步当前值到服务器Player对象上，需要处理</summary>
        public void DesCall(bool syncId = false)
        {
            
            object[] objects;
            if (syncId) objects = new object[] { this[GameDBEvent.ConfigData_SyncID], des.Value };
            else objects = new object[] { des.Value };
#if SERVER
            CheckUpdate(3);
            GameDBEvent.OnSyncProperty?.Invoke(client, NetCmd.SyncPropertyData, (ushort)GameHashProto.CONFIG_DES, objects);
#else
            GameDBEvent.Client.SendRT(NetCmd.SyncPropertyData, (ushort)GameHashProto.CONFIG_DES, objects);
#endif
        }

        [Rpc(hash = (ushort)GameHashProto.CONFIG_DES)]
        private void DesRpc(String value)//重写NetPlayer的OnStart方法来处理客户端自动同步到服务器数据库, 方法内部添加AddRpc(data(ConfigData));收集Rpc
        {
            Des = value;
        }
     //2

        public ConfigData() { }

    #if SERVER
        public ConfigData(params object[] parms) : base()
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
                case 1: length = 255; return "name";
     //3
                case 2: length = 0; return "count";
     //3
                case 3: length = 255; return "des";
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
                    case 1: return this.name.Value;
     //5
                    case 2: return this.count.Value;
     //5
                    case 3: return this.des.Value;
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
                        CheckNameValue((String)value, -1);
                        break;
     //7
                    case 2:
                        CheckCountValue((Int32)value, -1);
                        break;
     //7
                    case 3:
                        CheckDesValue((String)value, -1);
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
                    case "name": return this.name.Value;
     //9
                    case "count": return this.count.Value;
     //9
                    case "des": return this.des.Value;
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
                    case "name":
                        CheckNameValue((String)value, -1);
                        break;
     //11
                    case "count":
                        CheckCountValue((Int32)value, -1);
                        break;
     //11
                    case "des":
                        CheckDesValue((String)value, -1);
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
        public static ConfigData Query(string filterExpression)
        {
            var cmdText = $"select * from config where {filterExpression}; ";
            var data = GameDB.I.ExecuteQuery<ConfigData>(cmdText);
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
        public static async UniTask<ConfigData> QueryAsync(string filterExpression)
        {
            var cmdText = $"select * from config where {filterExpression}; ";
            var data = await GameDB.I.ExecuteQueryAsync<ConfigData>(cmdText);
            return data;
        }
        public static ConfigData[] QueryList(string filterExpression)
        {
            var cmdText = $"select * from config where {filterExpression}; ";
            var datas = GameDB.I.ExecuteQueryList<ConfigData>(cmdText);
            return datas;
        }
        public static async UniTask<ConfigData[]> QueryListAsync(string filterExpression)
        {
            var cmdText = $"select * from config where {filterExpression}; ";
            var datas = await GameDB.I.ExecuteQueryListAsync<ConfigData>(cmdText);
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
            if (row[1] is String name)
                CheckNameValue(name, -1);
     //15
            if (row[2] is Int32 count)
                CheckCountValue(count, -1);
     //15
            if (row[3] is String des)
                CheckDesValue(des, -1);
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
            string cmdText = $"DELETE FROM config {CheckSqlKey(0, id)}";
            sb.Append(cmdText);
            RowState = DataRowState.Deleted;
    #endif
        }

    #if SERVER
        public void BulkLoaderBuilder(StringBuilder sb)
        {
 
            for (int i = 0; i < 4; i++)
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
                        NDebug.LogError($"config表{name}列长度溢出!");
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
            return $"Id:{Id} Name:{Name} Count:{Count} Des:{Des} ";
        }
    }
