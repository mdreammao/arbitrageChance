using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace arbitrageChance
{
    class StoreData
    {
        public StoreData(List<optionDataFormat> myData,int start=0,int end=0)
        {
            if (start==0)
            {
                start = 0;
                end = myData.Count() - 1;
            }
            if (start!=0 && start<myData.Count() && end==0)
            {
                end = myData.Count() - 1;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("代码", Type.GetType("System.String"));
            dt.Columns.Add("日期", Type.GetType("System.String"));
            dt.Columns.Add("时间", Type.GetType("System.Double"));
            dt.Columns.Add("成交价", Type.GetType("System.Double"));
            dt.Columns.Add("Ask1", Type.GetType("System.Double"));
            dt.Columns.Add("Ask2", Type.GetType("System.Double"));
            dt.Columns.Add("Ask3", Type.GetType("System.Double"));
            dt.Columns.Add("Ask4", Type.GetType("System.Double"));
            dt.Columns.Add("Ask5", Type.GetType("System.Double"));
            dt.Columns.Add("Askv1", Type.GetType("System.Double"));
            dt.Columns.Add("Askv2", Type.GetType("System.Double"));
            dt.Columns.Add("Askv3", Type.GetType("System.Double"));
            dt.Columns.Add("Askv4", Type.GetType("System.Double"));
            dt.Columns.Add("Askv5", Type.GetType("System.Double"));
            dt.Columns.Add("bid1", Type.GetType("System.Double"));
            dt.Columns.Add("bid2", Type.GetType("System.Double"));
            dt.Columns.Add("bid3", Type.GetType("System.Double"));
            dt.Columns.Add("bid4", Type.GetType("System.Double"));
            dt.Columns.Add("bid5", Type.GetType("System.Double"));
            dt.Columns.Add("bidv1", Type.GetType("System.Double"));
            dt.Columns.Add("bidv2", Type.GetType("System.Double"));
            dt.Columns.Add("bidv3", Type.GetType("System.Double"));
            dt.Columns.Add("bidv4", Type.GetType("System.Double"));
            dt.Columns.Add("bidv5", Type.GetType("System.Double"));
            dt.Columns.Add("high", Type.GetType("System.Double"));
            dt.Columns.Add("low", Type.GetType("System.Double"));
            dt.Columns.Add("成交量", Type.GetType("System.Double"));
            dt.Columns.Add("成交额", Type.GetType("System.Double"));
            dt.Columns.Add("持仓量", Type.GetType("System.Double"));
            dt.Columns.Add("成交笔数", Type.GetType("System.Double"));
            dt.Columns.Add("状态", Type.GetType("System.String"));
            string str = DateTime.Now.ToString("yyyyMMdd");
            lock(myData)
            {
                for (int i = start; i <=end; i++)
                {
                    optionDataFormat data = myData[i];
                    dt.Rows.Add(new object[] { data.code, str, data.time, data.last, data.ask[0], data.ask[1], data.ask[2], data.ask[3], data.ask[4], data.askv[0], data.askv[1], data.askv[2], data.askv[3], data.askv[4], data.bid[0], data.bid[1], data.bid[2], data.bid[3], data.bid[4], data.bidv[0], data.bidv[1], data.bidv[2], data.bidv[3], data.bidv[4], data.high, data.low, data.volume, data.turnover, data.openInterest, data.count, data.status });
                }
            }
            CsvApplication.SaveCSV(dt, "optiondata_" + str + ".csv", "append");
        }
    }
}
