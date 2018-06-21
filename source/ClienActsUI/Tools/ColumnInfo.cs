namespace OverWeightControl.Clients.ActsUI.Tools
{
    public class ColumnInfo
    {
        public string Name { get; set; }
        public int Num { get; set; }
        public bool Visible { get; set; }
        public string Description { get; set; }

        /// <summary>Возвращает строку, представляющую текущий объект.</summary>
        /// <returns>Строка, представляющая текущий объект.</returns>
        public override string ToString() => Name;
    }
}