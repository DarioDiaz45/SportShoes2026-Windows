using SportShoes2026.Service.DTOs.Sport;
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
                case SportListDto sportShoeDto:
                    r.Cells[0].Value = sportShoeDto.SportId;
                    r.Cells[1].Value = sportShoeDto.SportName;
                    r.Cells[2].Value = sportShoeDto.IsActive;
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
