using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbitrageChance
{

    /// <summary>
    /// 期权相关合约信息
    /// </summary>
    struct optionRelation
    {
        public List<string> box,timespread;
        public string future,spotStock,parity;
    }    
    /// <summary>
    /// 存储数据信息的结构体。    /// </summary>
    struct dataFormat
    {
        public string code, status;
        public long date,time;
        public double[] ask, askv, bid, bidv;
        public decimal high, low, last, openInterest, turnover, volume, count;
    }


    /// <summary>
    /// 存储期权基本信息的结构体。
    /// </summary>
    struct optionFormat
    {
        public int optionCode;
        public string optionName;
        public int startDate;
        public int endDate;
        public string optionType;
        public string executeType;
        public double strike;
        public string market;
    }

    /// <summary>
    /// 存储期权数据的结构体。包含13个字段。
    /// </summary>
    struct optionDataFormat
    {
        public string code, status;
        public int[] ask, askv, bid, bidv;
        public long high, low, last, openInterest, time, turnover, volume,count;
    }

    /// <summary>
    /// 需要提取TDB数据的品种信息。
    /// </summary>
    struct TDBdataInformation
    {
        public string market;
        public int startDate;
        public int endDate;
        public string type;
    }
    /// <summary>
    /// 记录TDB连接信息的结构体。
    /// </summary>
    struct TDBsource
    {
        public string IP;
        public string port;
        public string account;
        public string password;
        public TDBsource(string IP, string port, string account, string password)
        {
            this.IP = IP;
            this.port = port;
            this.account = account;
            this.password = password;
        }
    }
}
