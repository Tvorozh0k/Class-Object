// Класс - выводимое сообщение
class Message 
{
    private String msg;
    
    public Message(String str) { msg = str; }
    
    public void setMsg(String str) { msg = str; }
    
    public String getMsg() { return msg; }
}

// Класс, одижающий другие потоки, пока они не закончат выполнение
class Waiter implements Runnable 
{
    private Message msg;
    
    public Waiter(Message m) { msg = m; }
    
    @Override
    public void run()
    {
        String name = Thread.currentThread().getName();
        
        synchronized(msg)
        {
            try 
            {
                System.out.println(name + " ждем вызов метода notify: " + System.currentTimeMillis());
                msg.wait();
            } 
            catch(InterruptedException e) 
            {
                e.printStackTrace();
            }
            
            System.out.println(name + " : " + msg.getMsg());
        }
    }
}

// Класс, обрабатывающий объект Message и вызывающий notify
class Notifier implements Runnable 
{
    private Message msg;
    
    public Notifier(Message msg) { this.msg = msg; }
    
    @Override
    public void run()
    {
        String name = Thread.currentThread().getName();
        System.out.println(name + " стартовал");
        
        try
        {
            Thread.sleep(1000);
            
            synchronized(msg)
            {
                msg.setMsg(name + " поток Notifier отработал");
                //msg.notify();
                msg.notifyAll();
            }
        }
        catch(InterruptedException e)
        {
            e.printStackTrace();
        }
    }
}

public class Main
{
	public static void main(String[] args) 
	{
		Message msg = new Message("обработать");
		
		Waiter waiter1 = new Waiter(msg);
		new Thread(waiter1, "waiter1").start();
		
		Waiter waiter2 = new Waiter(msg);
		new Thread(waiter2, "waiter2").start();
		
		Notifier notifier = new Notifier(msg);
		new Thread(notifier, "notifier").start();
		
		System.out.println("Стартовали все потоки");
	}
}
