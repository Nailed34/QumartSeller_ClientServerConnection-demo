### QumartSeller_ClientServerConnection
Данная библиотека классов (.Net 8) используется в следующих репозиториях сервиса QumartSeller:<br/>
https://github.com/Nailed34/QumartSeller_Client-demo <br/>
https://github.com/Nailed34/QumartSeller_Server-demo <br/>
Nuget пакет предназначен для подключения клиенту и серверу общей логики:<br/>
- ProductInfo и ProductInfoCard - классы для представления объединений карточек с нужной клиенту информацией в виде свойств и методами для сериализации и десериализацией данных для передачи с помощью веб-сокета.
- Actions - хранит классы для отправляемых и принимаемых запросов относительно клиента (префикс In* - для отправляемых данных на сервер и Out* - для принимаего ответа от сервера). Каждый запрос находится в отдельном файле.

### Установка пакета <br/>
Пакет можно подключить с помощью команды
```
$ dotnet add package QumartSeller_ClientServerConnection --version 0.1.2-alpha
```
