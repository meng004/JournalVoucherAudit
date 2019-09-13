using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                return number;
            }
        }
    }
}
