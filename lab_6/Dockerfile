FROM python:3.11-slim

WORKDIR /app

COPY . .

RUN ls -la
RUN pip install --no-cache-dir -r requirements.txt
RUN pip install pytest

# Команда для запуску тестів
CMD ["pytest"]
