#if SERVER 
using System;
using System.Collections.Generic;

namespace Game
{
    //GameDB��д�ļ�
    public partial class GameDB
    { 
        private readonly object SyncRoot = new object();
        public Dictionary<string, UserinfoData> Users = new Dictionary<string, UserinfoData>();
        public Dictionary<ConfigType, ConfigData> Configs = new Dictionary<ConfigType, ConfigData>();

        public void OnInit(List<object> list)
        {
            InitConfigs(list);
            InitUsers(list);
        }

        private void InitUsers(List<object> list)
        {
            Users.Clear();
            foreach (var item in list)
            {
                if (item is UserinfoData data1)
                {
                    Users[data1.Account] = data1;
                }
            }
        }

        private void InitConfigs(List<object> list)
        {
            Configs.Clear();
            foreach (var item in list)
            {
                if (item is ConfigData data1)
                {
                    Configs[(ConfigType)data1.Id] = data1;
                }
            }
        }


        /// <summary>
        /// ��ȡ���ñ��ĳ��������������
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int ConfigAdd(ConfigType type)
        {
            lock (SyncRoot)
            {
                if (!Configs.TryGetValue(type,out var data))
                {
                    Configs.Add(type, data = new ConfigData((int)type, type.ToString(), 1, $"��¼{type}������id����"));
                }
                return data.Count++;
            }
        }

        /// <summary>
        /// ��ȡdata����
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ConfigData Config(ConfigType type)
        {
            lock (SyncRoot)
            {
                if (Configs.TryGetValue(type, out var data))
                {
                    Configs.Add(type, data = new ConfigData((int)type, type.ToString(), 1, $"��¼{type}������id����"));
                }
                return data;
            }
        }

        internal bool TryGetUser(string account, out UserinfoData data)
        {
            return Users.TryGetValue(account, out data);
        }
        internal void AddUser(UserinfoData data)
        {
            Users[data.Account] = data;
        }
    }
}
#endif