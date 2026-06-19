using Microsoft.Extensions.DependencyInjection;
using SportShoes2026.Service.DTOs.Genre;
using SportShoes2026.Service.Interfaces;

namespace SportShoes2026.Windows
{
    public partial class frmGenre : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private List<GenreListDto>? _listGenres;
        public frmGenre(IServiceProvider serviceprovider)
        {
            InitializeComponent();
            _serviceProvider = serviceprovider;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            using var scope = _serviceProvider.CreateScope();

            var genreService = scope.ServiceProvider
                .GetRequiredService<IGenreService>();

            var lista = genreService.GetList();

            MostrarDatosEnGrilla(lista);
        }

        private void MostrarDatosEnGrilla(List<GenreListDto> lista)
        {
            dgvDatos.Rows.Clear();

            foreach (var item in lista)
            {
                var r = new DataGridViewRow();

                r.CreateCells(dgvDatos);

                SetearFila(r, item);

                dgvDatos.Rows.Add(r);
            }
        }

        private void SetearFila(DataGridViewRow r, GenreListDto item)
        {
            r.Cells[colIdGenre.Index].Value = item.GenreId;
            r.Cells[colTypeGenre.Index].Value = item.GenreName;
            r.Cells[colActive.Index].Value = item.Active;

            r.Tag = item;
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            RecargarGrilla();
        }
    }
}
