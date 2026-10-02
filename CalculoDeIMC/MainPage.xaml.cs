namespace CalculoDeIMC;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        AtualizarPesoIdeal(AlturaSlider.Value);
    }

   
    private void AlturaSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        AlturaLabel.Text = $"{e.NewValue:F2} m";

        AtualizarPesoIdeal(e.NewValue);
    }

    
    private void PesoSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        PesoLabel.Text = $"{e.NewValue:F0} kg";
    }

    
    private void AtualizarPesoIdeal(double altura)
    {
        
        double imcMinimo = 18.5;

       
        double imcMaximo = 24.9;

       

        double pesoMinimo = imcMinimo * (altura * altura);
        double pesoMaximo = imcMaximo * (altura * altura);

        PesoIdealLabel.Text =
            $"{pesoMinimo:F1} kg até {pesoMaximo:F1} kg";
    }

   
    private async void OnCounterClicked(object sender, EventArgs e)
    {
        string nome = NomeInput.Text ?? "";
        string idade = IdadeInput.Text ?? "";
        string sexo = SexoInput.Text ?? "";

        double altura = AlturaSlider.Value;
        double peso = PesoSlider.Value;

        // Calcula o IMC
        double imc = peso / (altura * altura);

        string classificacao;

        if (imc < 18.5)
        {
            classificacao = "Abaixo do peso";
        }
        else if (imc < 25)
        {
            classificacao = "Peso normal";
        }
        else if (imc < 30)
        {
            classificacao = "Sobrepeso";
        }
        else if (imc < 35)
        {
            classificacao = "Obesidade grau I";
        }
        else if (imc < 40)
        {
            classificacao = "Obesidade grau II";
        }
        else
        {
            classificacao = "Obesidade grau III";
        }

        // Calcula a faixa de peso sugerida
        double pesoMinimo = 18.5 * (altura * altura);
        double pesoMaximo = 24.9 * (altura * altura);

        await DisplayAlert(
            "Resultado do IMC",

            $"Altura: {altura:F2} m\n" +
            $"Peso atual: {peso:F0} kg\n\n" +

            $"IMC: {imc:F2}\n" +
            $"Classificação: {classificacao}\n\n" +

            $"Peso sugerido para sua altura:\n" +
            $"{pesoMinimo:F1} kg até {pesoMaximo:F1} kg",

            "OK");
    }
}
