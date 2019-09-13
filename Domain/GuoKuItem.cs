using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                //取出数字
                var number = sbc.GetNumber();
                return number;
            }
        }
    }
}
