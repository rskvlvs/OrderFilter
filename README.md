Консольное приложение на C#, которое фильтрует заказы на основе заданных критериев: района доставки (cityDistrict) и даты первого заказа (firstDeliveryDateTime). Отфильтрованные заказы записываются в указанный файл вместе с логами приложения. Приложение использует несколько библиотек для гибкости и расширяемости:
- FluentValidation для проверки корректности данных заказов,
- NLog для логирования работы приложения,
- Newtonsoft.Json для работы с JSON-файлами,
- Microsoft.Extensions.DependencyInjection для внедрения зависимостей (DI).
Файлы конфигурации:
FilterParams.json: файл конфигурации, где задаются параметры фильтрации.
Пример пути: OrderFilter\OrderFilter\bin\Debug\net8.0\FilterParams.json
Параметры:
_cityDistrict — район доставки для фильтрации заказов.
_firstDeliveryDateTime — минимальная дата доставки.
_deliveryLog — путь к файлу для записи логов.
_deliveryOrder — путь к файлу для записи отфильтрованных заказов.
orders.json: файл с входящими заказами для фильтрации.
Пример пути: OrderFilter\OrderFilter\bin\Debug\net8.0\orders.json
