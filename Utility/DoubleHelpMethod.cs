using System;

namespace JournalVoucherAudit.Utility
{
    public class DoubleHelpMethod
    {
        /// <summary>
        /// 误差阈值
        /// </summary>
        private double _threshold = 1e-5;
        public DoubleHelpMethod()
        {

        }
        /// <summary>
        /// 初始化误差阈值
        /// </summary>
        /// <param name="threshold"></param>
        public DoubleHelpMethod(double threshold)
        {
            _threshold = threshold;
        }
        /// <summary>
        /// 比较两个浮点数是否相等
        /// </summary>
        /// <param name="doubleX"></param>
        /// <param name="doubleY"></param>
        /// <returns></returns>
        public bool IsEqual(double doubleX, double doubleY)
        {
            //return Math.Abs(doubleX - doubleY) - double.Epsilon < _threshold;
            return Math.Abs(doubleX - doubleY) < _threshold;
        }
    }
}
