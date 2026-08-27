using SportShoes2026.Service.DTOs.Brand;
using SportShoes2026.Service.Interfaces;
using SportShoes2026.Windows.Helpers;

namespace SportShoes2026.Windows
{
    public partial class frmBrandAe : Form
    {
        private BrandUpdateDto? _brandUpdateDto;
        private readonly IBrandService _brandServicio;
        private bool _esEdicion = false;
        public frmBrandAe(IBrandService brandServicio)
        {
            InitializeComponent();
            _brandServicio = brandServicio;
        }
        public int UltimoId { get; private set; }
        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_brandUpdateDto is null)
            {
                chkActive.Checked = true;
                chkActive.Enabled = false;

            }
            else
            {
                txtNameBrand.Text = _brandUpdateDto.BrandName;
                txtCountry.Text = _brandUpdateDto.Country;
                chkActive.Checked = _brandUpdateDto.Active;
                chkActive.Enabled = true;
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

                        var _brandCreateDto = new BrandCreateDto();
                        _brandCreateDto.BrandName = txtNameBrand.Text;
                        _brandCreateDto.Country = txtCountry.Text;
                        var resultadoAgregar = _brandServicio.Add(_brandCreateDto);
                        if (resultadoAgregar.IsFailure)
                        {
                            ErrorHelper.MostrarErrores(resultadoAgregar.Errors);
                            return;
                        }
                        DataChanged = true;
                        UltimoId = resultadoAgregar.Value;
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
                        if (_brandUpdateDto is null)
                        {
                            _brandUpdateDto = new BrandUpdateDto();
                        }
                        _brandUpdateDto.BrandName = txtNameBrand.Text;
                        _brandUpdateDto.Country = txtCountry.Text;
                        _brandUpdateDto.Active = chkActive.Checked;

                        var resultadoEditar = _brandServicio
                            .Update(_brandUpdateDto);
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
                        MessageBox.Show("Registro editado satisfactoriamente",
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
            txtNameBrand.Clear();
            txtCountry.Clear();
            chkActive.Checked = true;
            chkActive.Enabled = false;
            txtNameBrand.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtNameBrand.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNameBrand, "El nombre es requerido");

            }
            if (string.IsNullOrEmpty(txtCountry.Text))
            {
                valido = false;
                errorProvider1.SetError(txtCountry, "El país es requerido");
            }
            return valido;
        }

        public void SetBrand(BrandUpdateDto? brandUpdateDto)
        {
            _brandUpdateDto = brandUpdateDto;
        }

        public BrandUpdateDto? GetBrand()
        {
            return _brandUpdateDto;
        }
    }
}
