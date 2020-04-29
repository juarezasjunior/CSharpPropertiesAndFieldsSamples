# Propriedades e Campos em C#

## Quais as diferenças entre campos e propriedades?
Os campos devem ser utilizados para colocar variáveis ou constantes internas de uma classe. Uma propriedade tem como objetivo expor esses campos para que outras classes acessem ela.
Embora eu posso colocar um campo como sendo público, essa não é uma boa prática.

## Exemplo 1 - Campos
Na pasta Samples dessa solução, temos o arquivo Sample1.cs.
Note abaixo os campos dessa classe:
```
        private int id;
        private string name;
        private int age;
        private string address;
```
Todos os campos são privados e, portanto, podem ser acessados apenas por essa classe.

## Exemplo 2 - Campos com Readonly
Na pasta Samples dessa solução, temos o arquivo Sample2.cs.
Note abaixo que nesse exemplo os campos estão com a palavra chave readonly após a palavra private.
```
        private readonly int id;
        private readonly string name;
```
Isso significa que esses campos serão visíveis na classe, mas só poderão receber valores se atribuídos na inicialização. 
Veja abaixo que no construtor atribuímos os valores desses campos:
```
        public Sample2(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
```
Porém, se em um método tentássemos atribuir um valor para esses campos, mesmo que esse método fosse dentro da própria classe que eles estão, eu teria um erro. Você pode visualizar esse erro descomentando os o código abaixo.
```
        public void AnotherMethod(int id, string name)
        {
            //You cannot set readonly fields outside the constructor

            //Try to uncomment the following lines and see the error
            //this.id = id;
            //this.name = name;
        }
```

## Exemplo 3 - Expondo/atribuindo campos com métodos
Na pasta Samples dessa solução, temos o arquivo Sample3.cs.
Os campos desse exemplo estão todos como privados. Porém temos métodos que expõem esses campos ou que permitem que outras classes atribuam valores para esses campos.
```
        public string GetName()
        {
            return this.name;
        }

        public void SetAge(int age)
        {
            if (age < 21)
            {
                throw new Exception("You cannot add a person that are not 21 years old or more.");
            }

            this.age = age;
        }

        public int GetAge(int age)
        {
            return this.age;
        }

        public string GetAddress()
        {
            return this.address;
        }
```
No método GetName, retornamos o campo name. 
No SetAge recebemos um valor e fazemos uma validação (nesse exemplo, se o valor for menor que 21 gera uma exceção). Caso passe na validação, o valor é atribuído ao campo age.
Quando fazemos dessa forma, é possível fazer valições nos valores que iremos atribuir bem como fazer mudanças nos valores que serão expostos.
Mas será que sempre precisamos criar métodos para isso?

## Exemplo 4 - Propriedades
Na pasta Samples dessa solução, temos o arquivo Sample4.cs.
As propriedades permitem fazer validações na atribuição de valores e expor campos sem criar métodos para isso. Veja o código abaixo:
```
        private int id;
        private string name;
        private int age;
        private string address;

        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 21)
                {
                    throw new Exception("You cannot add a person that are not 21 years old or more.");
                }

                this.age = value;
            }
        }
```
Note que uma propriedade tem as palavras get e set. E após as palavras get e set, nós temos um bloco de código. 
No bloco da palavra get, precisamos retornar um valor correspondente ao tipo dessa propriedade (veja a propriedade do tipo int chamada Age que retorna o campo interno age). 
No bloco da palavra set, tem uma outra palavra que é o value. Esse value representa o valor que foi atribuido no campo quando alguém fez assim: Age = 30. O valor 30 está na palavra value. Note também que dentro do bloco do set, foi feita uma validação, onde se o valor vindo for menor que 21, ele gera uma exceção.

Perceba também nos exemplos acima, que embora o campo id possa ser exposto para outra classe, outra classe não poderá atribuir um valor a ele, porque ele não tem o bloco de códigos do set.

Com isso, podemos ter campos, mas decidir quais serão expostos e quais poderão receber valores (inclusive criando regras para isso).

Mas, será que sempre precisamos ter um campo e uma propriedade?

## Exemplo 5 - Propriedades sem campos definidos explicitamente
Na pasta Samples dessa solução, temos o arquivo Sample5.cs.
Se desejarmos simplificar, podemos criar apenas propriedades sem criar os campos.
Internamente, ele terá criado os campos, mas você não os visualizará nem acessará eles diretamente, apenas usando as propriedades.
Assim, conforme o código abaixo, podemos simplesmente ter propriedades.
```
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
```
Note que nem sempre precisamos colocar {} no get e no set. Se você não deseja colocar validações ou mudar o jeito padrão, basta colocar get;set;. Se desejar, poderá colocar também apenas get ou apenas set.


## Exemplo 6 - Propriedades com private set
Na pasta Samples dessa solução, temos o arquivo Sample6.cs.
Quando criamos propriedades, podemos definir como private o set. Dessa forma, internamente, na própria classe, eu posso atribuir o valor daquela propriedade, mas fora da classe, consigo apenas pegar o valor.
Veja o código abaixo:
```
    public class Sample6
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; private set; }

        public Sample6(int id, string name, int age, string address)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Address = address;
        }

        public void ChangeId(int newId)
        {
            this.Id = newId;
        }
    }
```
As propriedades Id e Address não podem receber valores fora da classe, apenas internamente (como no construtor ou em outros métodos). Você pode criar um método para alterar a propriedade mas não pode alterar ela de fora.
Veja uma outra classe chamando a Sample6.
```
    public class UsingSample6
    {
        public void Using()
        {
            Sample6 sample6 = new Sample6(1, "John", 20, "20th street");

            sample6.Name = "Mary";

            //You cannot set a value for Id property, because the setter is private
            //Only the class can set its value
            //Uncomment the following line and you will see the error

            //sample6.Id = 15;
        }
    }
```
No exemplo acima, se descomentar a linha sample6.Id = 15, note que você receberá um erro.

## Exemplo 7 - Mais exemplos de propriedades
Na pasta Samples dessa solução, temos o arquivo Sample7.cs.
Nesse exemplo, podemos atribuir valores padrões para as propriedades de algumas maneiras.
```
        public int Id => 10;
        public string Name { get; set; } = "John";
        public int Age { get; private set; } = 21;
        public string Address { get; } = "20th avenue";
```
Note que na primeira propriedade, `public int Id => 10;` estamos atribuindo o valor 10 à propriedade Id. Porém, nesse layout, eu não posso atribuir à propriedade Id um outro valor, porque é como se ele tivesse criado ela apenas com o get, sem o set.
Na segunda, temos o get e o set, porém já atribuimos um valor padrão de "John".
Na terceira, temos o get e o private set (onde pode ser modificado o valor dela apenas na própria classe que a criou). Também
já atribuimos para ela um valor padrão, 21.
Na quarta, temos também apenas o get e já passamos um valor padrão.

