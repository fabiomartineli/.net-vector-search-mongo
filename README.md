# 🔎 Vector Searching no MongoDB com C# e .NET

## 📌 Contexto de Uso
Este projeto demonstra a utilização do Vector Searching no MongoDB para aplicar a busca por similaridade, explorando técnicas de busca vetorial dentro de uma base de dados NoSQL. A implementação é feita em C# e .NET, garantindo uma integração eficiente e performática com o banco de dados. Além disso, a geração de embeddings é realizada utilizando o Ollama localmente e o pacote OllamaClient, permitindo a criação de representações vetoriais de alta dimensão.
A busca por similaridade é uma técnica utilizada para encontrar itens que estão semanticamente próximos dentro de um espaço vetorial. Nesse método, os dados são convertidos em vetores numéricos e armazenados em uma base de dados. Quando um usuário realiza uma consulta, essa consulta também é transformada em um vetor e comparada com os vetores existentes utilizando métricas como distância euclidiana, similaridade cosseno, ou outras funções de similaridade.

## Diferença entre busca por Similaridade e RAG
- A busca por similaridade foca em encontrar elementos próximos dentro de um espaço vetorial, sem entender o contexto para gerar uma resposta customizada. 
- RAG combina a recuperação de dados com geração de novas informações, ou seja, entende o contexto para gerar uma informação mais complexa de acordo com as bases de dados disponíveis.

## 🚀 Desenvolvimento
O projeto foi desenvolvido com o objetivo de exemplificar como o MongoDB pode ser utilizado para realizar buscas vetoriais, facilitando consultas semânticas sobre dados armazenados. Ele utiliza a biblioteca oficial MongoDriver para integração com o banco de dados e a API do Ollama para a geração local de embeddings com 1024 dimensões.
A arquitetura segue um modelo simplificado onde os vetores são armazenados no MongoDB, permitindo consultas rápidas e eficientes através de funções de similaridade.

## 🛠 Tecnologias
Este projeto utiliza as seguintes tecnologias:
- C# e .NET - Plataforma de desenvolvimento robusta para aplicações escaláveis
- MongoDB - Banco de dados NoSQL utilizado para armazenar os vetores
- MongoDriver - Biblioteca oficial para integração do C# com o MongoDB
- Ollama - Ferramenta utilizada para a geração de embeddings executada localmente
- OllamaClient - Pacote de integração para facilitar a comunicação com o Ollama API

## Observações
- A definição da dimensão no index do vetor de busca semântica deve ser compatível com o número de dimensões gerada nos embeddings do modelo de AI escolhido. Nesse exemplo foi utilizado uma dimensão de 1024.
- O número de candidatos no método de busca vetorial significa a quantidade de registros que serão pré-selecionados e passarão por um filtro de similaridade.
- O nome do index deve ser o mesmo criado no banco de dados do MongoDB.
- Caso seja necessário filtros adicionais, os mesmos devem ser informados na criação do index.

## 🏁 Conclusão
Este projeto serve como uma introdução prática ao conceito de Vector Searching no MongoDB, demonstrando como é possível realizar buscas semânticas de alta performance utilizando C# e .NET. A combinação de Ollama para geração de embeddings e MongoDB para armazenamento dos vetores fornece um poderoso mecanismo de busca para diversos casos de uso, como recomendação de conteúdo, processamento de linguagem natural e recuperação de informações.
