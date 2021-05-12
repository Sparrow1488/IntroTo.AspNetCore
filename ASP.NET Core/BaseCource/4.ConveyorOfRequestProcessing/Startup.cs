using _4.ConveyorOfRequestProcessing.middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace _4.ConveyorOfRequestProcessing
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            /*
             *  ���� � ���, ��� �� �� ����� �������� ��������� �����, ���� �� ������������
             *  �.�., �� ������ � �������� �������� ������� ������
             *  ��������: /home?password=1488
             */
            app.UseMiddleware<AuthMiddleware>();
            app.UseMiddleware<RoutingMiddleware>();
        }
    }
}
