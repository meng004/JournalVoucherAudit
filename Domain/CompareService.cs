namespace JournalVoucherAudit.Domain
{
    /// <summary>
    /// 比较
    /// </summary>
    public class CompareService
    {
        /// <summary>
        /// 财务与国库是否相等
        /// 先比较凭证号，再比较金额
        /// 两者均相等，返回true
        /// 其它情况，返回false
        /// </summary>
        /// <typeparam name="Caiwu"></typeparam>
        /// <typeparam name="GuoKu"></typeparam>
        /// <param name="caiWu"></param>
        /// <param name="guoKu"></param>
        /// <returns></returns>
        public bool Equals<Caiwu, GuoKu>(Caiwu caiWu, GuoKu guoKu)
            where Caiwu : CaiWuItem
            where GuoKu : GuoKuItem
        {
            var result = false;
            //取凭证号
            var caiWuNumber = caiWu.Number;
            var guoKuNumber = guoKu.Number;
            //比较凭证号
            if (caiWuNumber == guoKuNumber)
            {
                //比较金额
                if (caiWu.CreditAmount == guoKu.Amount)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
