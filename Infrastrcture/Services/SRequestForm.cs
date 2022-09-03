using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
public class SRequestForm : IRequestForm
{
    private readonly Context db;
    private readonly IWebHostEnvironment env;
    public SRequestForm(Context _db, IWebHostEnvironment _env)
    {
        db = _db;
        env = _env;
    }
    public int AddForm(VmRequestForm Request)
    {
        RequestForm Form = new RequestForm()
        {
            Url = GetImageUrl(Request.Urlupload),
            PrimaryLang = Request.PrimaryLang,
            FileName = "Request.FileName",
            Email = "Request.Email",
            FormName = "Request.FormName",
            FullName = "Request.FullName",
            Status = true
        };
        if (Request.Urlupload == null)
        {
            return 0;
        }
        else
        {
            db.RequestForms.Add(Form);
            db.SaveChanges();
        }


        int id = db.RequestForms.OrderByDescending(a => a.Id).Select(a => a.Id).FirstOrDefault();

        var q = Request.Lang.Split(",");
        foreach (var item in q)
        {
            TranslateLang langu = new TranslateLang()
            {
                Lang = item,
                RequestFormId = id
            };
            db.TranslateLangs.Add(langu);
            db.SaveChanges();
        }
        return id;
    }
    public string GetImageUrl(IFormFile file)
    {
        string FileExtension2 = Path.GetExtension(file.FileName);
        string NewFileName = String.Concat(Guid.NewGuid().ToString(), FileExtension2);
        var path = $"{env.WebRootPath}\\fileupload\\{NewFileName}";
        using (var stream = new FileStream(path, FileMode.Create))
            file.CopyTo(stream);

        return NewFileName;
    }
    


    public VmRequestForm UpdateForm(VmRequestForm form)
    {
        var requestForm = db.RequestForms.Find(form.Id);

        requestForm.Email = form.Email;
        requestForm.FileName = form.FileName;
        requestForm.FormName = form.FormName;
        requestForm.FullName = form.FullName;
        requestForm.PrimaryLang = form.PrimaryLang;

        db.RequestForms.Update(requestForm);
        db.SaveChanges();
        return form;
    }
}