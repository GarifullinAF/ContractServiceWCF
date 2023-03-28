# ContractServiceWCF
Порядок запуска
1. В файле app.config решения WCFHost заполнить элемент connectionString. Нужно указать путь к .mdf файлу в параметре AttachDbFilename
2. От имени администратора запускаем WCFHost.exe
3. Запускаем приложение WPF клиента ContractService.Client.exe
