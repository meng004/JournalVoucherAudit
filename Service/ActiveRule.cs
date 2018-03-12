using System;
using System.ComponentModel;

namespace JournalVoucherAudit.Service
{
    /// <summary>
    /// 生效规则标记
    /// 新增标记应遵循：取前一项的2倍，如4后依次取8，16，32等
    /// </summary>
    [Flags]
    public enum ActiveRule
    {
        [Description("金额与记录数匹配规则生效")]
        AmountWithCount = 1,

        [Description("单条记录凭证号与金额匹配规则生效")]
        NumberWithSingleRecord = 2,

        [Description("凭证号与总金额匹配规则生效")]
        NumberWithAmount = 4,

        [Description("金额绝对值与金额合计匹配规则生效")]
        AbsWithAmount = 8,



    }
}
