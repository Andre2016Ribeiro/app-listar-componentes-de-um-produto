Capacidades Principais
O App Lista Componentes de um Produto é uma aplicação desktop desenvolvida em C# (.NET Windows Forms) que oferece as seguintes funcionalidades:

1. Consulta e Gestão de Dados SQL
Integração com banco de dados SQL Server para recuperar informações de artigos e seus componentes
Pesquisa dinâmica em tempo real de artigos por código ou descrição
2. Listagem de Componentes
Exibe os componentes que formam um produto com:
Código do componente
Descrição do componente
Quantidade/Consumo
Código de barras
Stock disponível em armazéns específicos
3. 🌐 Automação Web com Selenium (ChromeDriver)
Abre automaticamente páginas web internas em navegadores Chrome
Preenche formulários web com dados extraídos do banco de dados
Integra informações da aplicação desktop com sistemas web internos
4. Múltiplos Fluxos de Trabalho Integrados
A aplicação abre diferentes páginas conforme o tipo de artigo:

Tipo de Artigo	URL Alvo	Ação
Artigos de Fabrico (2-30AF)	http://10.0.0.243/gpr/pedidos_mp_Fabrico/pedidos_mp_fabrico.php	Preenche pedido de fabrico
Artigos A-Z	http://10.0.0.243/gpr/pedidos_MP_pintura/pedidos_MP_pintura.php	Preenche pedido de pintura
Outros Artigos	http://10.0.0.243/gpr/pedidos_mp/pedidos_MP.php	Preenche pedido genérico
Registros em Linha 1	http://10.0.0.243/SOFT/linha1/regL1_/regL1_.php	Preenche código de barras
Processos/Desenhos	http://10.0.0.243/GPR/ProcDesen.php/?artigo=	Abre dados de processo
5. Preenchimento Automático de Formulários
Os campos preenchidos automaticamente incluem:

pesquisa: Código do artigo
fillup: Quantidade (padrão "1")
cbUni: Unidade (padrão "Caixa")
cbLoc: Localização (padrão "Linha1")
cbPri: Prioridade (padrão "Urgência Média")
artigoCodBarras: Código de barras do artigo
6. Operações Múltiplas
3 modos de visualização de componentes (buttons 1, 2, 6)
Navegação entre componentes
Visualização com código 128 de barras
