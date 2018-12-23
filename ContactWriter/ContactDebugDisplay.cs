namespace ContactWriter
{

    internal class ContactDebugDisplay
    {
        private readonly Contact _contact;

        public ContactDebugDisplay(Contact contact)
        {
            _contact = contact;
        }

        public string UpperName => _contact.FirstName.ToUpperInvariant();

        public string AgeInHex => _contact.AgeInYears.ToString("X");

    }
}