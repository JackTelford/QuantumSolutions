using OrchardCore.Commerce.Inventory.Models;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using System.Threading.Tasks;

namespace OrchardCore.Commerce.Inventory.Migrations;

/// <summary>
/// Adds the inventory part to the list of available content parts.
/// </summary>
public class InventoryPartMigrations : DataMigration
{
    private readonly IContentDefinitionManager _contentDefinitionManager;

    public InventoryPartMigrations(IContentDefinitionManager contentDefinitionManager) =>
        _contentDefinitionManager = contentDefinitionManager;

    public int Create()
    {
        _contentDefinitionManager.AlterPartDefinition(nameof(InventoryPart), builder => builder
            .Attachable()
            .WithDescription("Adds basic inventory management capabilities to a product.")
            .WithField(nameof(InventoryPart.AllowsBackOrder), field => field
                .WithDisplayName("Allows Back Order")
                .WithSettings(new BooleanFieldSettings
                {
                    DefaultValue = false,
                    Hint = "Allows ordering even if Inventory is less than or equal to zero.",
                })
            )
            .WithField(nameof(InventoryPart.IgnoreInventory), field => field
                .WithDisplayName("Ignore Inventory")
                .WithSettings(new BooleanFieldSettings
                {
                    DefaultValue = false,
                    Hint = "Makes it so Inventory is ignored (same as if no InventoryPart was present). Useful for digital products for example.",
                })
            )
            .WithField(nameof(InventoryPart.MaximumOrderQuantity), field => field
                .WithDisplayName("Maximum Order Quantity")
                .WithSettings(new NumericFieldSettings
                {
                    Hint = "The maximum number of this item one can order. Ignored if set to zero or a negative value.",
                })
            )
            .WithField(nameof(InventoryPart.MinimumOrderQuantity), field => field
                .WithDisplayName("Minimum Order Quantity")
                .WithSettings(new NumericFieldSettings
                {
                    Hint = "The minimum number of this item one can order. Ignored if set to zero or a negative value.",
                })
            )
            .WithField(nameof(InventoryPart.OutOfStockMessage), field => field
                .WithDisplayName("Out of Stock Message")
                .WithEditor("Multiline")
                .WithSettings(new HtmlFieldSettings
                {
                    Hint = "Enables a specific message for an out of stock product. Can be used to give an ETA.",
                })
            )
        );

        return 1;
    }
}
