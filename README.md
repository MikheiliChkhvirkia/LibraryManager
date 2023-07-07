# LibraryManager

მოგესალმებით,

1. პროექტის გასაშვებად აუცილებლად უნდა მიენიჭოს LibraryManagement.API Layer-ს SetAsStartupProject

2. Package Manager Console-ში Default Project-ად უნდა იყოს არჩეული Source\LibraryManagement.Persistence და აუცილებლად უნდა გაიწეროს შემდეგი update-database ბაზის ლოკალურად დასარეგისტრირებლად.
თუ ბაზის სერვერის სახელი localhost დაკავებულია მაშინ appsetting-ში უნდა გაეწეროს 
    
"SQL": "Server=localhost;Database=LibraryManagement;user id=appUser;password=fkfi3n#m3;Encrypt=false;Trusted_Connection=True;MultipleActiveResultSets=true;trustServerCertificate=true;"

localhost-ის ნაცვლად შესაბამისი სახელი.

3. ბაზების წარმატებით დარეგისტრირების შემდეგ ჩვენ შეგვიძლია გამოვიყენოთ LibraryManagement აპლიკაცია.

Book-ის შექმნისას File უნდა იყოს ატვირთული თუ უნდა მიებას სურათი თუ არადა File AddFile endpoint-ით გააგზავნით სურათს მოგივათ Guid და გაატანთ Books მოდელს. Book-ს შეიძლება არ მიანიჭოთ სურათი და ავტორები,

თუმცა შეგიძლიათ სურათი შემდეგ მიაბათ წიგნს, ასევე ავტორები.


