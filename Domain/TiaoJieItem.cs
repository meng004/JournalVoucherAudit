namespace JournalVoucherAudit.Domain
{
    public class TiaoJieItem
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
    }
}