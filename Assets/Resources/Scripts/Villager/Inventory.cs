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

    public void addQuanity(float quantity) {
        actualQuantity += quantity;
    }

    public float getActualQuantity() {
        return actualQuantity;
    }

    public float getMaxCapacity() {
        return maxCapacity;
    }
}
