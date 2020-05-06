using JournalVoucherAudit.Utility;

namespace JournalVoucherAudit.Domain
{
    /// <summary>
    /// 国库，直接公共
    /// </summary>
    public class GuoKuItem
    {
        /// <summary>
        /// 支付令编号
        /// </summary>
        public string PaymentNumber { get; set; }
        /// <summary>
        /// 支付令生成日期
        /// </summary>
        public string CreateDate { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public double Amount { get; set; }
        /// <summary>
        /// 摘要事由
        /// </summary>
        public string RemarkReason { get; set; }
        /// <summary>
        /// 从摘要事由中取出凭证号
        /// </summary>
        /// <returns></returns>
        public string Number
        {
            get
            {
                //转半角
                var sbc = RemarkReason.ToSbc();
                
                //提取凭证号，格式为“报版面费4-1087”，4为四月，1087为凭证号
                var pingzhen = sbc.Split('-');
                //-号前的字符
                var result = pingzhen[0];
                //如果有-号，则取-号后的字符
                if (pingzhen.Length == 2)
                {
                    result = pingzhen[1];
                }
                //取出数字
                var number = result.GetNumber();
                return number;
            }
        }
    }
}
