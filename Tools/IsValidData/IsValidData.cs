namespace RentX.Tools.IsValidData
{
    public static class IsValidData
    {
        public static bool IsValid(string value1)
        {
            return string.IsNullOrWhiteSpace(value1);
        }

        public static bool IsValid(string value1, string value2)
        {
            var v1 = string.IsNullOrWhiteSpace(value1);
            var v2 = string.IsNullOrWhiteSpace(value2);

            return v1 || v2;
        }

        public static bool IsValid(string value1, string value2, string value3)
        {
            var v1 = string.IsNullOrWhiteSpace(value1);
            var v2 = string.IsNullOrWhiteSpace(value2);
            var v3 = string.IsNullOrWhiteSpace(value3);

            return v1 || v2 || v3;
        }
    }
}
