این یک مثال ساده از استفاده از مدل sqlCoder جهت تبدیل زبان طبیعی به کد sql است 
جهت استفاده از sqlcoder llm باید ابتدا به سایت https://ollama.com رفته و ollama  رو دانلود کنیم ، بعد از نصب رو ویندوز میتونیم با تایپ دستور 
ollama --version
از ران بودنش مطوئن بشیم 
حالا باید مدل مد نظرمون رو با دستور 
ollama pull sqlcoder 
ابتدار دانلود و سپس با دستور 
ollam run sqlcoder
اجرا کنیم ، بعد از اجرا باید بدونیم که ollama یک api  داره که روی 
POST http://localhost:11434/api/generate
بهش گوش میده 
من یک asp.net core web api  ساده نوشتم که یک کلاس داره با عنوان ollamaService در پوشه service  , d و یک کنترلر با عنوان TextTosql که استفاده ازش هم خیلی ساده س کافیه سولوشن رو ران کنیم و با استفاده از swagger  یا paostman این جی سان رو براش بفرستیم به صورت مثال 
{
  "prompt": " I have a table in sqlServer database named tbl_patients with the columns pat_id, first_name, last_name, recep_date that stores a list of patients admitted to the hospital. I want to have an sql query that returns the list of 10 patients who have been recently admitted. Return only the SQL code. "
}
جی سان بالا رو به اکشن post موجود در textTosql controller میفرستم و این دیتا رو ازش تحویل میگیرم 
{
  "sql": " Select top 10 pat_id, first_name, last_name FROM tbl_patients WHERE recep_date >= GETDATE() order by recep_date desc;"
}
این مهمه که پرامپت رو با دقت و جزییات براش بفرستیم
