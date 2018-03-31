# dotnet-socket

* **프로젝트 소개**
```
	*. 서버-클라이언트 간 통신 도구인 소켓(Socket)을 사용한 심플 메신저 서비스.
	
	*. 하나의 서버로 여러 클라이언트를 수용(accept)하기 위해, Non-Blocking 방식의 메커니즘으로 개발.
```
---

* **개발 환경**
```
	*. Windows 10
	
	*. .NET Framework 4.5.2
	
	*. Windows Forms
	
	*. Windows Socket
```

* **샘플 예제**
```
/* 클라이언트 연결 대기 */
private void AcceptLoop()
{
	while (true)
	{
		try
		{
			Socket workerSocket = listenSocket.Accept();
			if (workerSocket.Connected == false)
			{
				break;
			}

			// Client로 부터 연결(connect) 요청된 경우, 상호간 통신을 담당할 쓰레드 생성
			startInteractionThread(workerSocket);
		}
		catch (Exception) {

		}
	}
}

/* 클라이언트와 세션이 형성된 후, 통신을 담당할 쓰레드 실행 */
private void startInteractionThread(Socket workerSocket)
{
	Thread interactionThread = new Thread(new ParameterizedThreadStart(Interact));
	interactionThread.Start(workerSocket);
}

/* 서버-클라이언트 간 상호 작용 */
private void Interact(object workerSocket)
{
	while(true)
	{
		try
		{
			Byte[] buffer = new Byte[1024];

			//Client가 메시지를 전송할 때까지 대기
			((Socket) workerSocket).Receive(buffer);

			if (lb_msgs.InvokeRequired)
			{
				lb_msgs.Invoke(new AddItem(AddMsg), new object[] { buffer });
			}
		}
		catch (Exception)
		{
			return;
		}
	}
}
```
