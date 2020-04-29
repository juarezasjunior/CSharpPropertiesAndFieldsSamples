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
Na pasta Samples dessa solução, temos o arquivo Sample4.cs.
