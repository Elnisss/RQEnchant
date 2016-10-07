namespace RQEnchant
{
    public class EnchIterationStateBase
    {
        public int EcnhPremPiece { get; set; }
        public int EcnhAshkPiece { get; set; }
        public string StoneType { get; set; }
        public bool RuneIsUsed { get; set; }

        public EnchIterationStateBase(int ecnhPermPiece, int ecnhAshkPiece, string stoneType, bool runeIsUsed)
        {
            EcnhPremPiece = ecnhPermPiece;
            EcnhAshkPiece = ecnhAshkPiece;
            StoneType = stoneType;
            RuneIsUsed = runeIsUsed;
        }
    }
}