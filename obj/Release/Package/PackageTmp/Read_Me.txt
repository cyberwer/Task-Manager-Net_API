
This contians ideas and recouses that were refences. Do not delete.
T

TASK TO DO
!. Implement logging (event, error) on all methods.
2. Check existing lisecne login in Registers methods.
3. Implement 3rd party API for Payment, Documents Signature, SMS


AZURE RESOURCES
https://www.youtube.com/watch?v=tDuruX7XSac&feature=youtu.be

Azure Worker ROles
https://social.technet.microsoft.com/wiki/contents/articles/2173.azure-and-sql-database-tutorials-tutorial-4-using-windows-azure-worker-role-and-windows-azure-queue-service/rss.aspx
https://www.c-sharpcorner.com/article/worker-role-in-azure-cloud-service/


WEB API
https://dotnettutorials.net/lesson/web-api-architecture/
Model Binding in WebApi
https://www.dotnettricks.com/learn/webapi/model-binding-model-binder-example
https://docs.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/model-validation-in-aspnet-web-api

Web api with Angular in same project
https://www.youtube.com/watch?v=u7-cNIqQsRk

ANGULAR 
https://www.youtube.com/watch?v=Q8hm0vilhUU
https://developer.okta.com/blog/2018/07/27/build-crud-app-in-aspnet-framework-webapi-and-angular

AUTHENICATION AND AUTHERIZATION
JWT Authenication and Autherization is implemented.
Refer to following references for detail.
https://bitoftech.net/2015/01/21/asp-net-identity-2-with-asp-net-web-api-2-accounts-management/
https://github.com/tjoudeh/AspNetIdentity.WebApi/tree/master/AspNetIdentity.WebApi

Two factor enable
https://docs.microsoft.com/en-us/aspnet/mvc/overview/security/aspnet-mvc-5-app-with-sms-and-email-two-factor-authentication


DO NOT UPDATE:
Do NOT Update  System.IdentityModel.Tokens.Jwt  -Version 4.0.2.206221351
Requires install-Package System.IdentityModel.Tokens.Jwt  -Version 4.0.2.206221351


MODEL VALIDATION
Following calsses validate model for null check:
ValidateModelStateAttribute.cs
CheckModelForNullAttribute.cs

Usage:
Use following annotations.
[CheckModelForNull]
[ValidateModelState]
public void Post(Team team)
Reference: https://www.strathweb.com/2012/10/clean-up-your-web-api-controllers-with-model-validation-and-null-check-filters/

PAYMENT PROCESSING
For payemnt processing, we are using STRIP API integration.
See the following reference for guidence:
https://www.codementor.io/@sovitpoudel/asp-net-integration-with-stripe-arm46wai0


BEST PRATICES REFERNCES
https://medium.com/@schneidenbach/restful-api-best-practices-and-common-pitfalls-7a83ba3763b5
https://docs.microsoft.com/en-us/azure/architecture/best-practices/api-implementation



WORKER ROLES
Use for uploading documents to BLOB Storage
https://www.c-sharpcorner.com/article/worker-role-in-azure-cloud-service/
https://social.technet.microsoft.com/wiki/contents/articles/2173.azure-and-sql-database-tutorials-tutorial-4-using-windows-azure-worker-role-and-windows-azure-queue-service/rss.aspx


SQL ADO.NET DATABASE LAYER
http://csharpdocs.com/how-to-create-sql-data-access-layer-in-c-using-ado-net-part-1/

VIDEO CONFERENCING / CHAT RECOURSES
Use Towilo API for Chat, Video Conf. Email. SMS
https://developers.sinch.com/docs/building-your-own-conferencing-system-with-aspnet-mvc-part-1-getting-started
https://www.twilio.com/docs/voice/tutorials/conference-broadcast-csharp-mvc
https://forums.asp.net/t/2102004.aspx?How+to+create+video+conference+in+asp+net+mvc+

Screen Sharing
https://www.c-sharpcorner.com/uploadfile/ulricht/how-to-create-a-simple-screen-sharing-application-in-C-Sharp/
https://stackoverflow.com/questions/3295309/simple-c-sharp-screen-sharing-application

Capctacha
http://www.dotnetfunda.com/articles/show/3302/implementing-simple-custom-captcha-in-aspnet-mvc

Anti FOrge
http://benohead.com/asp-net-mvc-the-required-anti-forgery-form-field-__requestverificationtoken-is-not-present/


File download
https://stackoverflow.com/questions/34498184/difference-between-filecontentresult-and-filestreamresult
https://www.c-sharpcorner.com/blogs/how-to-open-pdf-file-in-new-tab-in-mvc-using-c-sharp
https://stackoverflow.com/questions/19411335/make-a-file-open-in-browser-instead-of-downloading-it
https://www.aspsnippets.com/Articles/Retrieve-and-display-PDF-Files-from-database-in-browser-in-ASPNet.aspx

Fire virus scan on Azure
https://stackoverflow.com/questions/54362257/how-can-i-scan-for-virus-in-azure-app-service-when-uploading-a-file-using-mvc-no
https://forums.asp.net/t/2126723.aspx?Antivirus+to+scan+files+before+uploading


Azure blob sample
https://www.dotnetcurry.com/windows-azure/1099/azure-storage-api-aspnet-mvc
https://azure.microsoft.com/en-us/blog/microsoft-antimalware-for-azure-cloud-services-and-virtual-machines/
https://blogs.msdn.microsoft.com/azuresecurity/2016/01/07/antimalware-for-azure-cloud-services-and-virtual-machines/


Create WEBSITE UPLOAD TO IIS
https://www.youtube.com/watch?v=yDZdUXPPRsM&feature=youtu.be

SendGrid APIKey
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


MICS.
For more information on how to enable account confirmation and password reset please visit
http://go.microsoft.com/fwlink/?LinkID=320771
Send an email with this link 
https://code.msdn.microsoft.com/ASPNET-MVC-5-Conferma-30d8b426




 

