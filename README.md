### QumartSeller общее<br/>
Qumart Seller - сервис для синхронизации остатков продавца на популярных маректплейсах, таких как Ozon, Wildberries и Yandex Market. Является pet-проектом и выложен с целью демонстрации знаний в среде .Net</br>
На данный момент сервис состоит 2 частей:
- Клиент: написан при помощи WPF C# (.Net 8) с применением паттерна MVVM и библиотекой CommunityToolkit.
- Сервер: ASP.Net C# (.Net 8) с применением SignalR (веб-сокеты) и подключением к базе данных MongoDB.

### Что умеет сервис?<br/>
- Импортировать карточки товаров в базу данных на сервере.
- Объединять карточки с разных маркетплейсов одного товара (с одинаковым артикулом) в отдельное представление, называемое ProductOnion (объединение).
- Синхронизировать остаток у карточек, которые находятся в одном объединении, т.е. при покупке товара, например на Wildberries, сервис автоматически вычтет остаток в других прикрепленных маркеплейсах.
- Настраивать синхронизацию у каждой конкретной карточки.
- Управлять объединенями вручную, в случаях если артикулы карточек различаются, но нужно чтобы они синхронизировались.
- Настраивать кратность покупки у каждой карточки, например если в объединении находится один и тот же товар, но представленный в разном количестве, сервис автоматически вычтет указанное количество в прикрепленных к объединению карточках.
- Отправлять общий остаток на маркетплейсы.

### Что реализовано на данный момент?<br/>
- Авторизация пользователя с применением JWT токена.
- Импорт товаров и остатков с маркетплейса Ozon (применяется официальный Ozon API, работающий через REST).
- Автоматическое создание/прикрепление/удаление объединений при импорте.
- Постраничная навигация по импортированным товарам на клиенте.
- Автоматическое кэширование фотографий на клиенте для их быстрого отображения.

### Что находится в демо версии?<br/>
В демо версии доступно всё, что реализованно на данный момент, за исключением логики импорта товаров/остатков с Ozon с созданием объединений, работающей непосредственно с базой данных.
Для тестирования функционала создан отдельный Демо сервис, генерирующий тестовые данные при запуске сервера, которые он отправляет при запросах клиента.

### Каким образом обрабатываются запросы клиента?<br/>
Общение между клиентом и сервером реализовано преимущественно с применением SignalR, что позволяет поддерживать активное соединение и отображаемые на клиенте данные в актульном состоянии.
Аутентификация пользователя реализована с помощью POST метода с генерацией JWT токена, который используется в авторизации соединения по веб-сокету.

### Какая архитектура сервиса?<br/>
На данный момент сервис имеет монолитную архитектуру, однако основной функционал раздроблен на отдельные несвязные библиотеки, которые легко можно будет развернуть в микросервисы, поэтому, если изолировать логику этих библиотек, текущий сервер
выполняет лишь роль шлюза и шины данных для будущих микросервисов.

### QumartSeller_ClientServerConnection
Данный репозиторий содержит библиотеку классов (.Net 8), представленную в виде Nuget пакета, предназначенной для подключения клиенту и серверу общей логики:<br/>
- ProductInfo и ProductInfoCard - классы для представления объединений карточек с нужной клиенту информацией в виде свойств и методами для сериализации и десериализацией данных для передачи с помощью веб-сокета.
- Actions - хранит классы для отправляемых и принимаемых запросов относительно клиента (префикс In* - для отправляемых данных на сервер и Out* - для принимаего ответа от сервера). Каждый запрос находится в отдельном файле.

### Установка пакета <br/>
Пакет находится в источнике пакетов github, поэтому для установки необходимо добавить в файл NuGet.config проекта следующие параметры:<br/>
```
<configuration>
  <packageSources>
    <add key="github" value="https://nuget.pkg.github.com/Nailed34/index.json" />
  </packageSources>
  <packageSourceCredentials>
    <github>
      <add key="Username" value="YOUR_USERNAME" />
      <add key="ClearTextPassword" value="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" />
    </github>
  </packageSourceCredentials>
</configuration>
```
Затем пакет можно будет подключить в менеджере пакетов Nuget в Visual Studio (указать источник пакетов github и включить предварительные версии)<br/>
или с помощью команды
```
$ dotnet add package QumartSeller_ClientServerConnection --version 0.1.2-alpha
```
