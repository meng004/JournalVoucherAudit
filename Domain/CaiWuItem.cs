using JournalVoucherAudit.Utility;

namespace JournalVoucherAudit.Domain
{
    /// <summary>
    /// 财务，财政补助收入
    /// </summary>
    public class CaiWuItem
    {
        /// <summary>
        /// 凭证号
        /// </summary>
        public string VoucherNumber { get; set; }
        /// <summary>
        /// 凭证日期
        /// </summary>
        public string VoucherDate { get; set; }
        /// <summary>
        /// 贷方金额
        /// </summary>
        public double CreditAmount { get; set; }
        /// <summary>
        /// 摘要
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 制单人
        /// </summary>
        public string Originator { get; set; }
        /// <summary>
        /// 科目编号
        /// </summary>
        public string SubjectCode { get; set; }
        /// <summary>
        /// 取出凭证号
        /// </summary>
        /// <returns></returns>
        public string Number
        {
            get
            {
                //转换为半角
                var sbc = VoucherNumber.ToSbc();
                //取数字
                var number = sbc.GetNumber();
                //去掉前面的零，如0487转换为487
                var result = number.TrimStart('0');
                return result;
            }
        }
    }
}
