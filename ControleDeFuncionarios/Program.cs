using ControleDeFuncionarios.Controllers;

//Instanciando a classe de controle de funcionários

var funcionarioController = new FuncionarioController();

//Executando o método de cadastro de funcionário
funcionarioController.CdastrarFuncionario();

//Pausar o console[
Console.ReadKey();