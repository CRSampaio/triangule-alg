using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

const string expressaoRegexApenasNumeros = @"^[+]?(?:\d+([.]\d+)?)$";
var regexApenasNumeros = new Regex(expressaoRegexApenasNumeros);
var inputs = new List<string?>(3);
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Verificação Triângulo");
Console.WriteLine();
Console.WriteLine("Digite o tamanho em cm do primeiro lado:");
inputs.Add(Console.ReadLine());

Console.WriteLine("Digite o tamanho em cm do segundo lado:");
inputs.Add(Console.ReadLine());

Console.WriteLine("Digite o tamanho em cm do terceiro lado:");
inputs.Add(Console.ReadLine());

if(inputs.Any(x => x is null))
{
    Console.WriteLine("Um dos lados do triângulo não foi informado");
    return;
}

if(inputs.Any(x => !regexApenasNumeros.IsMatch(x)))
{
    Console.WriteLine("Um dos lados do triângulo não foi um número");
    return;
}

var lados = inputs
            .Select(x => Convert.ToInt64(x))
            .ToList();

if(lados.Any(x => x.Equals(0)))
{
    Console.WriteLine("Valores informados não formam um triângulo");
    return;
}

if(lados.All(x => x.Equals(lados.First())))
    Console.WriteLine("Triângulo equilátero");
else if(lados.GroupBy(x => x)
            .Select(x => new {x.Key, Quantidade = x.Count()})
            .Any(x => x.Quantidade == 2))
    Console.WriteLine("Triângulo isósceles");
else
    Console.WriteLine("Triângulo escaleno");
