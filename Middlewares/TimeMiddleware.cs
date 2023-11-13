public class TimeMiddleware{

    readonly RequestDelegate next;

    public TimeMiddleware(RequestDelegate nextStep){
        next = nextStep;
    }

    public async Task Invoke(HttpContext context){

        await next(context);

        if(context.Request.Query.Any(p => p.Key == "time")){
            await context.Response.WriteAsync(DateTime.Now.ToShortDateString());
        }
    }

}

public static class TimeMiddlewareExtension{

    public static IApplicationBuilder useTimeMiddleware(this IApplicationBuilder builder){
        return builder.UseMiddleware<TimeMiddleware>();
    }
}