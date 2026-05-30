using SportShoes2026.Service.DTOs.SportShoe;

namespace SportShoes2026.Windows.Helpers
{
    public class GridHelper
    {
        public static void LimpiarGrilla(DataGridView grid)
        {
            grid.Rows.Clear();
        }

        public static DataGridViewRow ConstruirFila(DataGridView grid)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(grid);
            return r;
        }

        public static void SetearFila(DataGridViewRow r, object obj)
        {
            switch (obj)
            {
                case SportShoeListDto sportShoeDto:
                    r.Cells[0].Value = sportShoeDto.SportShoeId;
                    r.Cells[1].Value = sportShoeDto.Model;
                    r.Cells[2].Value = sportShoeDto.Price;
                    r.Cells[3].Value = sportShoeDto.BrandName;
                    r.Cells[4].Value = sportShoeDto.SizeNumber;
                    r.Cells[5].Value = sportShoeDto.SportName;
                    r.Cells[6].Value = sportShoeDto.GenreName;
                    break;
            }

            r.Tag = obj;
        }
        public static void AgregarFila(DataGridViewRow r, DataGridView grid)
        {
            grid.Rows.Add(r);
        }

        public static void QuitarFila(DataGridViewRow r, DataGridView grid)
        {
            grid.Rows.Remove(r);
        }
    }
}
