namespace test_codereview.Dto
{
    public record CotizacionResponse
    {
        public string Compra { get; init; }
        public string Venta { get; init; }

        public string Moneda { get; init; }

        public CotizacionResponse()
        {
        }

        public CotizacionResponse(string compra, string venta)
        {
            Compra = compra;
            Venta = venta;
        }
    }
}
