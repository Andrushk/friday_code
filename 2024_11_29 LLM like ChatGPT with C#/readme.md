# Запускаем БЯМ на LLamaSharp

LLamaSharp — это кроссплатформенная библиотека, позволяющая пользователям запускать LLM на своих устройствах локально. LLamaSharp основана на библиотеке C++ llama.cpp .

Вдохновление и код найдены тут:
https://code-maze.com/csharp-run-large-language-model-like-chatgpt-locally/

Ссылка иногда сбоит, поэтому вот ссылки на необходимые пакеты:
* dotnet add package LLamaSharp --version 0.11.2
* dotnet add package LLamaSharp.Backend.Cpu --version 0.11.2

Плюс ссылка на репо моделей: https://huggingface.co/

Конкретно использована вот эта модель: https://huggingface.co/TheBloke/phi-2-GGUF/blob/main/phi-2.Q4_K_M.gguf

##### Пример диалога

~~~
chatHistory.AddMessage(AuthorRole.System, @"Transcript of a conversation in which the User 
interacts with Assistant named Santa. Santa role is to be real Santa Claus. Assistant should be
very kind. In conversation assistant should play the role of a sweet kind grandfather.");

chatHistory.AddMessage(AuthorRole.User, "Hello, Santa.");
chatHistory.AddMessage(AuthorRole.Assistant, "Hello. How may I help you today my dear? Yo-ho-ho");
~~~

![dialog with Santa](dialog.jpg)

### Майкрософт тоже не спит и выпускает библиотеки Microsoft.Extensions.AI:

Microsoft.Extensions.AI — это набор основных библиотек .NET, разработанных в сотрудничестве с разработчиками экосистемы .NET, включая Semantic Kernel. Эти библиотеки предоставляют унифицированный уровень абстракций C# для взаимодействия со службами ИИ, такими как малые и большие языковые модели (SLM и LLM), встраивания и промежуточное ПО.

* https://devblogs.microsoft.com/dotnet/introducing-microsoft-extensions-ai-preview/
* https://devblogs.microsoft.com/semantic-kernel/microsoft-extensions-ai-simplifying-ai-integration-for-net-partners/


### Т-банк выложил свои БЯМы в открытый доступ

* https://huggingface.co/t-tech
* https://www.tbank.ru/about/news/11122024-the-t-technologies-group-has-introduced-the-worlds-most-efficient-open-large-language-models-in-russian/?utm_source=smm_tbank
