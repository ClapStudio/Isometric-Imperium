public class Inventory {

    private float maxCapacity;
    private float actualQuantity;

	public Inventory (float maxCapacity) {
        this.maxCapacity = maxCapacity;
        actualQuantity = 0;
    }

    public bool isFull() {
        if(actualQuantity >= maxCapacity) {
            return true;
        }
        return false;
    }
}
