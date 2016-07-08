using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace arbitrageChance
{
    class GetShotData
    {
        public Dictionary<string, dataFormat> marketInformation = new Dictionary<string, dataFormat>();
        public Dictionary<string, optionFormat> optionList = new Dictionary<string, optionFormat>();
        public OptionInformation myOption;
        public Dictionary<string, optionRelation> optionRelationList = new Dictionary<string, optionRelation>();
        public GetShotData()
        {
            myOption = new OptionInformation(20160701, 20160731);
            getRelation();
            findChance();
        }

        private void getRelation()
        {
            for (int i = 0; i < OptionInformation.myOptionList.Count(); i++)
            {
                optionFormat option = OptionInformation.myOptionList[i];
                optionRelation myRelation = new optionRelation();
                myRelation.box = new List<string>();
                myRelation.timespread = new List<string>();
                myRelation.spotStock = "510050.SH";
                for (int j = 0; j < OptionInformation.myOptionList.Count(); j++)
                {
                    if (i==j)
                    {
                        continue;
                    }
                    //跨期的合约
                    optionFormat optionOther = OptionInformation.myOptionList[i];
                    if (option.strike==optionOther.strike && option.optionType==optionOther.optionType)
                    {
                        myRelation.timespread.Add(optionOther.optionCode.ToString() + ".SH");
                    }
                    //平价套利
                    if (option.strike==optionOther.strike && option.optionType!=optionOther.optionType && option.endDate==optionOther.endDate)
                    {
                        myRelation.parity = optionOther.optionCode.ToString() + ".SH";
                    }
                    //箱体套利
                    
                }
            }
        }


        private void findChance()
        {
            DataTable dt = CsvApplication.OpenCSV("20160706.csv");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //模拟实时的行情
                dataFormat data0 = new dataFormat();
                data0.code = (string)dt.Rows[i]["代码"];
                if (data0.code == "代码")
                {
                    continue;
                }
                string[] str = data0.code.Split('.');
               int code =str[0][0]=='I'?0:Convert.ToInt32(str[0]);
                if (OptionInformation.myOptionList.ContainsKey(code) && optionList.ContainsKey(data0.code)==false)
                {
                    optionList.Add(data0.code, OptionInformation.myOptionList[code]);
                }

                data0.date = Convert.ToInt64(dt.Rows[i]["日期"]);
                data0.time = Convert.ToInt64(dt.Rows[i]["时间"]);
                data0.ask = new double[5];
                data0.ask[0] = Convert.ToDouble(dt.Rows[i]["Ask1"]) / 10000.0;
                data0.ask[1] = Convert.ToDouble(dt.Rows[i]["Ask2"]) / 10000.0;
                data0.ask[2] = Convert.ToDouble(dt.Rows[i]["Ask3"]) / 10000.0;
                data0.ask[3] = Convert.ToDouble(dt.Rows[i]["Ask4"]) / 10000.0;
                data0.ask[4] = Convert.ToDouble(dt.Rows[i]["Ask5"]) / 10000.0;
                data0.askv = new double[5];
                data0.askv[0] = Convert.ToDouble(dt.Rows[i]["Askv1"]) / 10000.0;
                data0.askv[1] = Convert.ToDouble(dt.Rows[i]["Askv2"]) / 10000.0;
                data0.askv[2] = Convert.ToDouble(dt.Rows[i]["Askv3"]) / 10000.0;
                data0.askv[3] = Convert.ToDouble(dt.Rows[i]["Askv4"]) / 10000.0;
                data0.askv[4] = Convert.ToDouble(dt.Rows[i]["Askv5"]) / 10000.0;
                data0.bid = new double[5];
                data0.bid[0] = Convert.ToDouble(dt.Rows[i]["Bid1"]) / 10000.0;
                data0.bid[1] = Convert.ToDouble(dt.Rows[i]["Bid2"]) / 10000.0;
                data0.bid[2] = Convert.ToDouble(dt.Rows[i]["Bid3"]) / 10000.0;
                data0.bid[3] = Convert.ToDouble(dt.Rows[i]["Bid4"]) / 10000.0;
                data0.bid[4] = Convert.ToDouble(dt.Rows[i]["Bid5"]) / 10000.0;
                data0.bidv = new double[5];
                data0.bidv[0] = Convert.ToDouble(dt.Rows[i]["Bidv1"]) / 10000.0;
                data0.bidv[1] = Convert.ToDouble(dt.Rows[i]["Bidv2"]) / 10000.0;
                data0.bidv[2] = Convert.ToDouble(dt.Rows[i]["Bidv3"]) / 10000.0;
                data0.bidv[3] = Convert.ToDouble(dt.Rows[i]["Bidv4"]) / 10000.0;
                data0.bidv[4] = Convert.ToDouble(dt.Rows[i]["Bidv5"]) / 10000.0;
                data0.high = Convert.ToDecimal(dt.Rows[i]["high"]) / 10000;
                data0.low=Convert.ToDecimal(dt.Rows[i]["low"]) / 10000;
                data0.last = Convert.ToDecimal(dt.Rows[i]["成交价"]) / 10000;
                data0.openInterest = Convert.ToDecimal(dt.Rows[i]["持仓量"]) / 10000;
                data0.status = (string)dt.Rows[i]["状态"];
                data0.turnover = Convert.ToDecimal(dt.Rows[i]["成交额"]);
                data0.volume = Convert.ToDecimal(dt.Rows[i]["成交量"]);
                if (marketInformation.ContainsKey(data0.code))
                {
                    marketInformation[data0.code] = data0;
                }
                else
                {
                    marketInformation.Add(data0.code, data0);
                }
            }
        }
    }
}
