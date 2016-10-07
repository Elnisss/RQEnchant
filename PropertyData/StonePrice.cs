using RQEnchant.Core;

namespace RQEnchant.PropertyData
{
    public class StonePrices : NotifyPropertyChangedBase
    {
        #region pieces
        public int AshkPrice
        {
            get { return _ashkPrice; }
            set
            {
                _ashkPrice = value;
                NotifyPropertyChanged("AshkPrice");
            }
        }

        public int BlackStPrice
        {
            get { return _blackStPrice; }

            set
            {
                _blackStPrice = value;
                NotifyPropertyChanged("BlackStPrice");
            }
        }

        public int WhiteStPrice
        {
            get { return _whiteStPrice; }

            set
            {
                _whiteStPrice = value;
                NotifyPropertyChanged("WhiteStPrice");
            }
        }

        public int RedStPrice
        {
            get { return _redStPrice; }

            set
            {
                _redStPrice = value;
                NotifyPropertyChanged("RedStPrice");
            }
        }

        public int RunePrice
        {
            get { return _runePrice; }

            set
            {
                _runePrice = value;
                NotifyPropertyChanged("RunePrice");
            }
        } 
        #endregion

        private int _ashkPrice;
        private int _blackStPrice;
        private int _whiteStPrice;
        private int _redStPrice;
        private int _runePrice;


        public StonePrices(int ashkPrice, int blackStPrice, int whiteStPrice, int redStPrice, int runePrice)
        {
            _ashkPrice = ashkPrice;
            _blackStPrice = blackStPrice;
            _whiteStPrice = whiteStPrice;
            _redStPrice = redStPrice;
            _runePrice = runePrice;
        }
        public void Copy(StonePrices sp)
        {
            _ashkPrice = sp.AshkPrice;
            _blackStPrice = sp.BlackStPrice;
            _whiteStPrice = sp.WhiteStPrice;
            _redStPrice = sp.RedStPrice;
            _runePrice = sp.RunePrice;
            NotifyPropertyChanged("AshkPrice");
            NotifyPropertyChanged("BlackStPrice");
            NotifyPropertyChanged("WhiteStPrice");
            NotifyPropertyChanged("RedStPrice");
            NotifyPropertyChanged("RunePrice");

        }
    }
}