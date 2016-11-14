namespace RegEx
{
    internal sealed class PostCodeValidator : InputValidator
    {
        internal override string Pattern => @"^[0-9]{6}$";
        internal override string SuccessMessage => "Correct post code";
        internal override string FailMessage => "Not a post code";
    }
}