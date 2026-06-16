using SportShoes2026.Service.DTOs.Brand;
using SportShoes2026.Service.DTOs.Sport;
using SportShoes2026.Service.Interfaces;
using SportShoes2026.Windows.Helpers;

namespace SportShoes2026.Windows
{
    public partial class frmSportAe : Form
    {
        private SportUpdateDto? _sportUpdateDto;
        private readonly ISportService _sportServicio;
        private bool _esEdicion = false;
        public frmSportAe(ISportService sportService)
        {
            InitializeComponent();
            _sportServicio = sportService;

        }
        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_sportUpdateDto is null)
            {
                chkActiveSport.Checked = true;
                chkActiveSport.Enabled = false;

            }
            else
            {
                txtSportName.Text = _sportUpdateDto.SportName;

                chkActiveSport.Checked = _sportUpdateDto.IsActive;
                chkActiveSport.Enabled = true;
                _esEdicion = true;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                try
                {
                    if (!_esEdicion)
                    {

                        var _tipoCreateDto = new SportCreateDto();
                        _tipoCreateDto.SportName = txtSportName.Text;
                        var resultadoAgregar = _sportServicio.Add(_tipoCreateDto);
                        if (resultadoAgregar.IsFailure)
                        {
                            ErrorHelper.MostrarErrores(resultadoAgregar.Errors);
                            return;
                        }
                        DataChanged = true;
                        var respuestaAgregarOtro = MessageBox.Show("Registro agregado\n¿Desea agregar otro?",
                                "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2);
                        if (respuestaAgregarOtro == DialogResult.No)
                        {
                            DialogResult = DialogResult.OK;
                        }
                        InicializarControles();

                    }
                    else
                    {
                        if (_sportUpdateDto is null)
                        {
                            _sportUpdateDto = new SportUpdateDto();
                        }
                        _sportUpdateDto.SportName = txtSportName.Text;
                        _sportUpdateDto.IsActive = chkActiveSport.Checked;

                        var resultadoEditar = _sportServicio
                            .Update(_sportUpdateDto);
                        if (resultadoEditar.IsConcurrencyConflict)
                        {
                            ErrorHelper.MostrarErrores(resultadoEditar.Errors);

                            ConcurrencyConflict = true;
                            DialogResult = DialogResult.Cancel;

                            Close();
                            return;
                        }
                        if (resultadoEditar.IsFailure)
                        {
                            ErrorHelper.MostrarErrores(resultadoEditar.Errors);
                            return;
                        }
                        DataChanged = true;
                        MessageBox.Show("Record successfully edited",
                            "Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InicializarControles()
        {
            txtSportName.Clear();
            chkActiveSport.Checked = true;
            chkActiveSport.Enabled = false;
            txtSportName.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtSportName.Text))
            {
                valido = false;
                errorProvider1.SetError(txtSportName, "El nombre es requerido");

            }
            return valido;
        }
        public void SetTipo(SportUpdateDto? tipoEditDto)
        {
            _sportUpdateDto = tipoEditDto;
        }
    }
}
