# CityTalk - будь всегда в курсе событий в твоем городе!

Приложение позволит отслеживать все происходящие и предстоящие события в городе, записываться на участие, оценивать события и организаторов.
Как организатор, пользователь сможет регистрировать события (как одноразовые, так и регулярные), привлекать участников, в будущем продавать билеты.
Как участиник, пользователь сможет просматривать список событий в интерфейсе приложения (на карте и списком), спиыватсья с организаторами, записываться на участие, оценивать события и организаторов, в будущем приобретать билеты.

<h2> Стек технологий </h2>

<ul>
<li>Kotlin - мобильное приложение</li>
<li>ASP.NET - сервер, API</li>
<li>PostgreSql - СУБД</li>
<li>Figma - дизайн</li>
<li>SingnalR - технология для RealTime взаимодействия</li>

</ul>

## Getting started

### Docker
Для загрузки docker-образа, выполните следующую команду(пока не реализовано):
```
docker pull v4dikos/citytalk:latest
```

### Docker-compose
Для запуска приложения, необходимо выполнить следующую команду(пока не реализовано):
```
docker-compose up -d
```
Для конфигурации сертфикатов для целей тестирования понадобится выполнить следующую команду:
```
dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p {{YOUR_PASSWORD}}
dotnet dev-certs https --trust
```

### Git
Для запуска приложения после загрузки из Git, понадобится настроить файл конфигурации.

### Структура appsettings.json (будет дополняться):
```json
{
  "ConnectionStrings": {
      "DbConnection": "your_npgsql_connection_string"
  },
  "Jwt": {
    "Issuer": "issuer",
    "Audience": "audience",
    "SecretKey": "your_secret_key"
  },
  "EmailOptions": {
    "ConfirmUrl": "email_confirm_url",
    "SenderName": "sender_name",
    "SenderEmail": "sender_email",
    "SmtpHost": "smtp_host",
    "SmtpPort": "smtp_port",
    "SmtpUsername": "user_login_for_the_smtp_server",
    "SmtpServicePassword": "user_password"
  },
  "s3StorageOptions": {
    "ServiceUrl": "provider_url_of_s3_storage",
    "BucketName": "your_bucket_name",
    "ReceiptLink": "your_link_for_documents_return"
  },
  "Aws": {
    "ServiceURL": "provider_url_of_s3_storage",
    "aws_access_key_id": "your_access_key_id",
    "aws_secret_access_key": "your_secret_access_key",
    "region": "region"
  },
  "AllowedHosts": "*"
}
```
