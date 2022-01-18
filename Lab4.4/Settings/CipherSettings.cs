namespace Lab4._4.Settings
{
    public class CipherSettings
    {
        public char[] Alphabet { init; get; } = new char[]
        {
            ' ', 'а', 'б', 'в', 'г', 'ґ', 'д', 'е',
            'є', 'ж', 'з', 'и', 'і', 'ї', 'й', 'к',
            'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т',
            'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь',
            'ю', 'я'
        };
        public int A { init; get; }
        public int B { init; get; }
        public int AReverted { init; get; }
    }
}
