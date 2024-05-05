using JMacasS5.Models;

namespace JMacasS5.Vistas;

public partial class VPersona : ContentPage
{
	public VPersona()
	{
		InitializeComponent();
        //listarPerosna();
    }

    private void btnIngresar_Clicked(object sender, EventArgs e)
    {
lblstatus.Text = "";
        App.personRepo.AddNewPerson(txtName.Text);
        lblstatus.Text = App.personRepo.StatusMessage;
        listarPerosna();
    }

    private void btnObtener_Clicked(object sender, EventArgs e)
    {
        /* lblstatus.Text = "";
         List<Persona>people=App.personRepo.getAllPeople();
         ListarPersona.ItemsSource = people;
         //ListarPersona.ItemsSource=people;
         lblstatus.Text=App.personRepo.StatusMessage;*/
        listarPerosna();
    }
    public void listarPerosna() {
        lblstatus.Text = "";
        List<Persona> people = App.personRepo.getAllPeople();
        ListarPersona.ItemsSource = people;
        //ListarPersona.ItemsSource=people;
        lblstatus.Text = App.personRepo.StatusMessage;

    }

    private async void Editar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
         var item = button.BindingContext as Persona; // Obtiene el objeto Persona seleccionado
        await Navigation.PushAsync(new Veditar(item)); // Pasa el objeto Persona a la página de edición

    


        listarPerosna();
    }

    private void Eliminar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var item = button.BindingContext as Persona; // Obtiene el objeto Persona seleccionado
        App.personRepo.DeletePerson(item.Id); // Elimina la persona de la base de datos
        btnObtener_Clicked(sender, e); // Actualiza la lista de personas
    }
}