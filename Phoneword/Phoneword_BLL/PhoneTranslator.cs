using System.Text;

namespace Phoneword_BLL
{
    public static class PhoneTranslator
    {
        private static string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string Numbers = "22233344455566677778889999";

        public static string ToNumber(string alphanumericPhoneNumber)
        {
            alphanumericPhoneNumber = alphanumericPhoneNumber.Trim();
            var NumericPhoneNumber = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(alphanumericPhoneNumber))
            {
                alphanumericPhoneNumber = alphanumericPhoneNumber.ToUpper();
                foreach (var c in alphanumericPhoneNumber)
                {
                    if ("0123456789".Contains(c.ToString() ) )
                    {
                        NumericPhoneNumber.Append(c);
                    }
                    else
                    {
                        var Index = Letters.IndexOf(c);
                        if (Index >= 0)
                        {
                            NumericPhoneNumber.Append(Numbers[Index]);
                        }
                    }
                }
            }
            return NumericPhoneNumber.ToString();
        }
    }
}
