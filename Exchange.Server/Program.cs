using Exchange.Trading;
using Microsoft.Extensions.Hosting;
using Orleans;
using Orleans.Hosting;

await Host.CreateDefaultBuilder(args)
    .UseOrleans((ctx, builder) =>
    {
        if (ctx.HostingEnvironment.IsDevelopment())
        {
            builder.UseLocalhostClustering();
            builder.AddMemoryGrainStorage("Exchange");
        }
        else
        {
            /*
            // In Kubernetes, we use environment variables and the pod manifest
            builder.UseKubernetesHosting();

            // Use Redis for clustering & persistence
            var redisAddress = $"{Environment.GetEnvironmentVariable("REDIS")}:6379";
            builder.UseRedisClustering(options => options.ConnectionString = redisAddress);
            builder.AddRedisGrainStorage("votes", options => options.ConnectionString = redisAddress);
            */
        }

        builder.UseDashboard(options =>
        {
            options.Port = 8888;
        })
        .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(Marker).Assembly));
    })
    .RunConsoleAsync();