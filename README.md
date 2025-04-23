# Text-to-SQL with sqlCoder & ASP.NET Core

این یک مثال ساده از استفاده از مدل **sqlCoder** جهت تبدیل زبان طبیعی به کد SQL است.

##  مراحل استفاده از مدل sqlCoder
برای استفاده از مدل `sqlCoder` به کمک LLMهای محلی:
<div dir="rtl">
1. به سایت [https://ollama.com](https://ollama.com) بروید و **Ollama** را برای سیستم خود (مثلاً ویندوز) دانلود و نصب کنید.
  <br>
2. برای اطمینان از نصب موفق، دستور زیر را اجرا کنید:
</div>
   

   ```bash
   ollama --version
   ```
<div dir="rtl">
   
4. سپس مدل مورد نظر را دانلود کرده و اجرا کنید:
 </div>
 
   ```bash
   ollama pull sqlcoder
   ollama run sqlcoder
   ```

   <div dir="rtl">

5. پس از اجرا، سرویس Ollama یک API فراهم می‌کند که روی آدرس زیر گوش می‌دهد:
   </div>


```bash
POST http://localhost:11434/api/generate
```

## درباره پروژه
در این پروژه، یک ASP.NET Core Web API ساده نوشته شده که شامل:
1. کلاسی با عنوان OllamaService در پوشه Services
2. کنترلری با عنوان TextToSqlController

## نحوه استفاده
پس از اجرای پروژه (با Visual Studio یا dotnet run)، می‌توانید از طریق Swagger یا Postman، درخواست زیر را به متد POST کنترلر TextToSql ارسال کنید:
###  درخواست نمونه 
```json
{
  "prompt": "I have a table in sqlServer database named tbl_patients with the columns pat_id, first_name, last_name, recep_date that stores a list of patients admitted to the hospital. I want to have an sql query that returns the list of 10 patients who have been recently admitted. Return only the SQL code."
}
```
### پاسخ نمونه 
```json
{
  "sql": "SELECT TOP 10 pat_id, first_name, last_name FROM tbl_patients WHERE recep_date >= GETDATE() ORDER BY recep_date DESC;"
}
```
**نکته مهم**
دقت در نوشتن prompt بسیار اهمیت دارد؛ حتماً به زبان انگلیسی و با جزئیات دقیق نیاز خود را بیان کنید تا مدل بهترین نتیجه را تولید کند.

